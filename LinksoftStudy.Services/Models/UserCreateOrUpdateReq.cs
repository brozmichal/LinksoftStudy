using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class UserCreateOrUpdateReq : IUserCreateOrUpdateReq
    { 
        public IUser User { get; set; }
    }
}
