using LinksoftStudy.Services.Models;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IUserStatistic
    {
        IPerson Person { get; set; }

        public int TotalFriends { get; set; }
    }
}
