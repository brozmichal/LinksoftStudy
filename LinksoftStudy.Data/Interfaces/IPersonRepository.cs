using LinksoftStudy.Data.Interfaces;
using LinksoftStudy.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinksoftStudy.Data.Interfaces
{
    public interface IPersonRepository : IRepository<PersonEntity>
    {
        Task<IEnumerable<PersonModel>> GetPeople(int skip = 0, int take = 20);

        Task<PersonModel> GetPerson(string personId);

        Task<PersonModel> CreateOrUpdatePerson(PersonModel person);

        Task<PersonStatisticsModel> GetUsersStatistics();
    }
}
