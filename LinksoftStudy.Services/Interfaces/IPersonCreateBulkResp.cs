using System.Collections.Generic;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IPersonCreateBulkResp
    {
        IEnumerable<IPerson> People { get; set; }
    }
}
