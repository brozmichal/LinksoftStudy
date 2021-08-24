using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class PersonGetResp : IPersonGetResp
    {
        public IPerson Person { get; set; }
    }
}
