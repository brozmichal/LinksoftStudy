using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class PersonGetReq : IPersonGetReq
    {
        public string PersonId { get; set; }
    }
}
