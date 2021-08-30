using LinksoftStudy.Data.Interfaces;
using LinksoftStudy.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinksoftStudy.Data.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<IEnumerable<UserModel>> GetUsers(int skip = 0, int take = 20);

        Task<UserModel> GetUser(string userId);

        Task<UserModel> CreateOrUpdateUser(UserModel person);

        Task<UserStatisticsModel> GetUsersStatistics();

        Task<IEnumerable<UserModel>> CreateUsers(IEnumerable<UserModel> users);
    }
}
