using LinksoftStudy.Services.Models;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IUserStatistic
    {
        IUser User { get; set; }

        public int TotalFriends { get; set; }
    }
}
