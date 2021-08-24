using System.Collections.Generic;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IPersonCreateBulkReq
    {
        IEnumerable<IPerson> People { get; set; }
    }
}
