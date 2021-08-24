using System.Threading.Tasks;

namespace LinksoftStudy.Web.Interfaces
{
    public interface IInputDataProcessor
    {
        Task<bool> Process(string filePath);
    }
}
