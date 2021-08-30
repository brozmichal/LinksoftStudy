using LinksoftStudy.Services.Interfaces;
using System.Collections.Generic;

namespace LinksoftStudy.Services.Models
{
    public class UserCreateBulkReq : IUserCreateBulkReq
    {
        public IEnumerable<IUser> Users { get; set; }
    }
}
