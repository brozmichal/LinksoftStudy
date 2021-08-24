using LinksoftStudy.Services.Interfaces;
using System.Collections.Generic;

namespace LinksoftStudy.Services.Models
{
    public class PersonCreateBulkResp : IPersonCreateBulkResp
    {
        public IEnumerable<IPerson> People { get; set; }
    }
}
