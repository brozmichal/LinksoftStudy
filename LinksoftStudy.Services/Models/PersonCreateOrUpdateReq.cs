using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class PersonCreateOrUpdateReq : IPersonCreateOrUpdateReq
    { 
        public IPerson Person { get; set; }
    }
}
