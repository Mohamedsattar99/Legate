using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailQuery: IRequest<GetUserDetailsVM>
    {
        public int Id { set; get; }
    }
}
