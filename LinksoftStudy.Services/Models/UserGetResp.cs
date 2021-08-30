using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class UserGetResp : IUserGetResp
    {
        public IUser User { get; set; }
    }
}
