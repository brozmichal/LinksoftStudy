using System.Collections.Generic;

namespace LinksoftStudy.Data.Models
{
    public class UserStatisticsModel
    {
        public IEnumerable<UserStatisticModel> Users;

        public int TotalUsers { get; set;}
    }
}
