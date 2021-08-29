using LinksoftStudy.Web.Interfaces;
using System.Collections.Generic;

namespace LinksoftStudy.Web.Models
{
    public class UserStatistics : IUserStatistics
    {
        public int AverageFriendshipsPerUser { get; set; }

        public int TotalUsers { get; set; }
    }
}
