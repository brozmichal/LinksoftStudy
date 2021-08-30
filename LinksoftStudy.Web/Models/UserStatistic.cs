using LinksoftStudy.Web.Interfaces;

namespace LinksoftStudy.Web.Models
{
    public class UserStatistic : IUserStatistic
    {
        public IUser Person { get; set; }

        public int TotalFriendShips { get; set; }
    }
}
