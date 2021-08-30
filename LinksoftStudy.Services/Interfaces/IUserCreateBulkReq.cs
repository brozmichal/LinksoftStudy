using System.Collections.Generic;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IUserCreateBulkReq
    {
        IEnumerable<IUser> Users { get; set; }
    }
}
