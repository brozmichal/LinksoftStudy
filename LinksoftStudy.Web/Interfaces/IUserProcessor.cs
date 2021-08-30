using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinksoftStudy.Web.Interfaces
{
    public interface IUserProcessor
    {
        Task<IEnumerable<IUser>> GetUsers();

        Task<IUserStatistics> GetUsersStatistics();
    }
}
