using System.Collections.Generic;
using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class PersonGetMultipleResp : IPersonGetMultipleResp
    { 
        public IEnumerable<IPerson> People { get; set; }
    }
}
