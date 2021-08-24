using LinksoftStudy.Services.Interfaces;
using System.Collections.Generic;

namespace LinksoftStudy.Services.Models
{
    public class PersonCreateBulkReq : IPersonCreateBulkReq
    {
        public IEnumerable<IPerson> People { get; set; }
    }
}
