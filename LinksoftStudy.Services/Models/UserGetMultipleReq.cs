using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class UserGetMultipleReq : IUserGetMultipleReq
    {
        public int Skip { get; set; }

        public int Take { get; set; }
    }
}
