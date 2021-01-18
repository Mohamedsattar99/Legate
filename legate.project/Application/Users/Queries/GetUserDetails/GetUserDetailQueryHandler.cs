using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, GetUserDetailsVM>
    {
        private readonly ILegateDbContext context;
        private readonly IMapper mapper;
        public GetUserDetailQueryHandler(ILegateDbContext legateDbContext, IMapper _mapper )
        {
            context = legateDbContext;
            mapper = _mapper;
        }
        public async Task<GetUserDetailsVM> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = context.Users.Where(a => a.Id == request.Id).FirstOrDefault();
            if(user == null)
            {
                throw  new NotFoundException(nameof(Domain.Entities.User), request.Id);
            }
            return  mapper.Map<GetUserDetailsVM>(user);

        }
    }
}
