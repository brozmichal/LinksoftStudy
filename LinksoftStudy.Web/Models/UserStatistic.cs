using LinksoftStudy.Web.Interfaces;

namespace LinksoftStudy.Web.Models
{
    public class UserStatistic : IUserStatistic
    {
        public IPerson Person { get; set; }

        public int TotalFriendShips { get; set; }
    }
}
