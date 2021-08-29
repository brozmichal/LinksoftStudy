using LinksoftStudy.Web.Interfaces;
using System.Collections.Generic;

namespace LinksoftStudy.Web.Interfaces
{
    public interface IUserStatistics
    {
        public int TotalUsers { get; set; }

        public int AverageFriendshipsPerUser { get; set; }
    }
}
