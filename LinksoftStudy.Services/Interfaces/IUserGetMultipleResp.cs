using System.Collections.Generic;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IUserGetMultipleResp
    {
        IEnumerable<IUser> Users { get; set; }
    }
}
