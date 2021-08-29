using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Interfaces
{
    public class UserStatistic : IUserStatistic
    {
        public IPerson Person { get; set; }

        public int TotalFriends { get; set; }
    }
}
