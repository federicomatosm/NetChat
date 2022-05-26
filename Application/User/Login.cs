using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<UserDto>
        {
            public string Email { get; set; }
            public string Password { get; set; }

        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.Email).EmailAddress();
            }
        }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly SignInManager<AppUser> _signinManager;
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IJwtGenerator jwtGenerator)
            {
                _signinManager = signinManager;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }
            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                    throw new RestException(System.Net.HttpStatusCode.Unauthorized);

                var result = await _signinManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                 
                    return new UserDto
                    {
                        Token = _jwtGenerator.CreateToken(user),
                        Email = user.Email,
                        UserName = user.UserName
                    };
                }

                throw new RestException(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}
