using System.Collections.Generic;

namespace LinksoftStudy.Common.Interfaces
{
    public interface IInputDataService
    {
        IEnumerable<IContactModel> ProcessInputFile(string path);
        
        IEnumerable<IContactModel> ProcessContent(string content);
    }
}
