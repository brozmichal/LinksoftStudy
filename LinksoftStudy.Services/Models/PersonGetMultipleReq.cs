using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class PersonGetMultipleReq : IPersonGetMultipleReq
    {
        public int Skip { get; set; }

        public int Take { get; set; }
    }
}
