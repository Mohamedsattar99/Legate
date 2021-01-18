using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly ILegateDbContext context;
        
        public DeleteUserCommandHandler(ILegateDbContext legateDbContext)
        {
            context = legateDbContext;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Users.FindAsync(request.Id);
            if(entity== null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User), request.Id);
            }
            context.Users.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
