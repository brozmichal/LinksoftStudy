using LinksoftStudy.Services.Interfaces;
using System.Collections.Generic;

namespace LinksoftStudy.Services.Models
{
    public class PersonGetStatisticsResp : IPersonGetStatisticsResp
    {
        public IEnumerable<UserStatistic> UserStatistics { get; set; }

        public int TotalUsers { get; set; }
    }
}
