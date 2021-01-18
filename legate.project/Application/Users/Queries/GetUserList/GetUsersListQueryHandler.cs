using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListVm>
    {
        private readonly ILegateDbContext context;
        private readonly IMapper mapper;
        public GetUsersListQueryHandler(ILegateDbContext legateDbContext, IMapper _mapper)
        {
            context = legateDbContext;
            mapper = _mapper;
        }
        public async Task<UsersListVm> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users= await context.Users.ProjectTo<UserLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var userVM = new UsersListVm
            {
                Users = users
            };
            return userVM;
        }
        
    }
}
