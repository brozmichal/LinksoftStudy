using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinksoftStudy.Web.Interfaces
{
    public interface IPersonProcessor
    {
        Task<IEnumerable<IPerson>> GetPeople();
    }
}
