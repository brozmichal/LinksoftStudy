using LinksoftStudy.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LinksoftStudy.Services.Models
{
    public class UserGetStatisticsResp : IUserGetStatisticsResp
    {
        public UserGetStatisticsResp()
        {
            UserStatistics = Enumerable.Empty<UserStatistic>();
        }

        public IEnumerable<UserStatistic> UserStatistics { get; set; }

        public int TotalUsers { get; set; }
    }
}
