using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksoftStudy.Common.Interfaces
{
    public interface IContactModel
    {
        string ContactPrimary { get; set; }

        string ContactSecondary { get; set; }
    }
}
