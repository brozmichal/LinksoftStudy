using System.Collections.Generic;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IUserCreateBulkResp
    {
        IEnumerable<IUser> Users { get; set; }
    }
}
