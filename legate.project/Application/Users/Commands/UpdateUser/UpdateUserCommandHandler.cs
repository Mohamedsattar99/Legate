using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ILegateDbContext context;
        private readonly IMapper mapper;
        public UpdateUserCommandHandler(ILegateDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Users.SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User), request.Id);
            }
            entity.Address = request.Address;
            entity.Name = request.Name;
            entity.Age = request.Age;
            entity.JoiningDate = DateTime.Parse(request.JoiningDate);
            entity.Phone = request.Phone;
            entity.Postion = request.Postion;
            entity.salary = request.salary;
            context.Users.Update(entity);
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
