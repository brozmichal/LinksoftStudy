using LinksoftStudy.Services.Interfaces;
using System.Collections.Generic;

namespace LinksoftStudy.Services.Models
{
    public class UserCreateBulkResp : IUserCreateBulkResp
    {
        public IEnumerable<IUser> Users { get; set; }
    }
}
