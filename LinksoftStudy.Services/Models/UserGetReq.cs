using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class UserGetReq : IUserGetReq
    {
        public string UserId { get; set; }
    }
}
