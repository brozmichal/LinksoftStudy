using System.Collections.Generic;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IPersonGetMultipleReq
    {
        int Skip { get; set; }

        int Take { get; set; }
    }
}
