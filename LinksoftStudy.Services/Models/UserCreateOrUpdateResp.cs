using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class UserCreateOrUpdateResp : IUserCreateOrUpdateResp
    { 
        public IUser User { get; set; }
    }
}
