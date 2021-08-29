using System.Collections.Generic;

namespace LinksoftStudy.Data.Models
{
    public class PersonStatisticsModel
    {
        public IEnumerable<PersonStatisticModel> Users;

        public int TotalUsers { get; set;}
    }
}
