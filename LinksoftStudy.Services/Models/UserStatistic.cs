using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Interfaces
{
    public class UserStatistic : IUserStatistic
    {
        public IUser User { get; set; }

        public int TotalFriends { get; set; }
    }
}
