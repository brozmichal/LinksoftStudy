using System.Collections.Generic;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IPersonGetMultipleResp
    {
        IEnumerable<IPerson> People { get; set; }
    }
}
