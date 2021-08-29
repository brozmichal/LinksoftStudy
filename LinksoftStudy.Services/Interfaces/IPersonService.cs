using LinksoftStudy.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinksoftStudy.Services.Interfaces
{
    public interface IPersonService
    {
        Task<IPersonGetResp> GetPerson(IPersonGetReq req);

        Task<IPersonCreateOrUpdateResp> CreateOrUpdatePerson(IPersonCreateOrUpdateReq req);

        Task<IPersonCreateBulkResp> CreateBulk(IPersonCreateBulkReq req);

        Task<IPersonGetMultipleResp> GetPeople(IPersonGetMultipleReq req);

        Task<IPersonGetStatisticsResp> GetStatistics();
    }
}
