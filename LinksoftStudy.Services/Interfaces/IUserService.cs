using LinksoftStudy.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IUserService
    {
        Task<IUserGetResp> GetUser(IUserGetReq req);

        Task<IUserCreateOrUpdateResp> CreateOrUpdateUser(IUserCreateOrUpdateReq req);

        Task<IUserCreateBulkResp> CreateBulk(IUserCreateBulkReq req);

        Task<IUserGetMultipleResp> GetUsers(IUserGetMultipleReq req);

        Task<IUserGetStatisticsResp> GetStatistics();
    }
}
