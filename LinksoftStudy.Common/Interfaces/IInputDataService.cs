using LinksoftStudy.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinksoftStudy.Common.Interfaces
{
    public interface IInputDataService
    {
        IEnumerable<ContactModel> ProcessInputFile(string path);
        
        IEnumerable<ContactModel> ProcessContent(string content);
    }
}
