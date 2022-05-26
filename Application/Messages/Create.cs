using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Messages
{
    public class Create
    {
       public class Command: IRequest<MessageDto>
        {
            public string Content { get; set; }
            public Guid ChannelId { get; set; }
            public MessageType MessageType { get; set; }

        }

        public class Handler : IRequestHandler<Command, MessageDto>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }
            public async Task<MessageDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = _context.Users.SingleOrDefaultAsync(x=> x.UserName == _userAccessor.GetCurrentUserName());
                throw new NotImplementedException();
            }
        }
    }
}
