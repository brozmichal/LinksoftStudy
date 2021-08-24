using LinksoftStudy.Services.Interfaces;
using LinksoftStudy.Services.Models;
using LinksoftStudy.Web.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksoftStudy.Web.Processors
{
    public class PersonProcessor : IPersonProcessor
    {
        private readonly IPersonService personService;

        public PersonProcessor(
                IPersonService personService)
        {
            this.personService = personService;
        }

        public async Task<IEnumerable<Interfaces.IPerson>> GetPeople()
        {
            var resp = await this.personService.GetPeople(new PersonGetMultipleReq());
            if (resp == null)
            {
                // log
                return null;
            }

            return resp.People
                .Select(person => new Models.Person()
                {
                    PersonId = person.PersonId
                }).AsEnumerable();
        }
    }
}