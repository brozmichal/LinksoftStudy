using System.Collections.Generic;
using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class UserGetMultipleResp : IUserGetMultipleResp
    { 
        public IEnumerable<IUser> Users { get; set; }
    }
}
