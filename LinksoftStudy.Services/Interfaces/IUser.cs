using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IUser
    {
        string UserId { get; set; }

        string ContactId { get; set; }
    }
}
