using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest<UserDto>
        {

            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class CommandValidator: AbstractValidator<Command>
        {
            private UserManager<AppUser> userManager;

            public CommandValidator(UserManager<AppUser> userManager)
            {
                RuleFor(x => x.UserName)
                    .NotEmpty()
                    .MustAsync(async (userName, CancellationToken) =>  await userManager.FindByNameAsync(userName) == null)
                    .WithMessage("email address already exist");
                RuleFor(x => x.Email)
                    .NotEmpty()
                    .EmailAddress()
                    .MustAsync(async (email, CancellationToken) => await userManager.FindByEmailAsync(email) == null)
                    .WithMessage("email address already exist"); 
                RuleFor(x => x.Password)
                    .NotEmpty()
                    .Password();

                this.userManager = userManager;
            }
        }

        public class Handler : IRequestHandler<Command, UserDto>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
            {
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }

            

            public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
            {
               

                var user = new AppUser { Email = request.Email, UserName = request.UserName };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return new UserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _jwtGenerator.CreateToken(user)
                    };
                }

                throw new Exception("Error registering user");
            }
        }
    }
}
