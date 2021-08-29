using LinksoftStudy.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksoftStudy.Data.Models
{
    public interface IPersonModel
    {
        string PersonId { get; set; }

        string ContactId { get; set; }
    }
}
