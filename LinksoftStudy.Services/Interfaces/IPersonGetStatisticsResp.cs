﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IPersonGetStatisticsResp
    {
        IEnumerable<UserStatistic> UserStatistics { get; set; }

        int TotalUsers { get; set; }
    }
}
