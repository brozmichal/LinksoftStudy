using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class PersonCreateOrUpdateResp : IPersonCreateOrUpdateResp
    { 
        public IPerson Person { get; set; }
    }
}
