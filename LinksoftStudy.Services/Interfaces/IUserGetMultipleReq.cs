using System.Collections.Generic;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IUserGetMultipleReq
    {
        int Skip { get; set; }

        int Take { get; set; }
    }
}
