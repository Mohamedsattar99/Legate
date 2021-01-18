using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetUserList
{
   public class UsersListVm
    {
        public IList<UserLookupDto> Users { set; get; }
    }
}
