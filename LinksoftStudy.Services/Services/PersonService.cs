using AutoMapper;
using LinksoftStudy.Data.Interfaces;
using LinksoftStudy.Data.Models;
using LinksoftStudy.Services.Interfaces;
using LinksoftStudy.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksoftStudy.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper mapper;

        private readonly IPersonRepository personRepository;

        public PersonService(
            IMapper mapper,
            IPersonRepository personRepository)
        {
            this.mapper = mapper;
            this.personRepository = personRepository;
        }

        public async Task<IPersonGetMultipleResp> GetPeople(IPersonGetMultipleReq req)
        {
            var resp = await this.personRepository.GetPeople(req.Skip, req.Take);

            var result = new PersonGetMultipleResp();
            if (resp == null)
            {
                result.People = Enumerable.Empty<Person>();
            };

            result.People = resp.Select(person => this.mapper.Map<Person>(person)).AsEnumerable();

            return result;
        }

        public async Task<IPersonCreateOrUpdateResp> CreateOrUpdatePerson(IPersonCreateOrUpdateReq req)
        {
            if (string.IsNullOrEmpty(req?.Person.PersonId))
            {
                return null;
            }

            var dataModel = mapper.Map<PersonModel>(req);

            var resp = await this.personRepository.CreateOrUpdatePerson(dataModel);
            if (resp == null)
            {
                // log error
                return null;
            }

            return new PersonCreateOrUpdateResp()
            {
                Person = this.mapper.Map<Person>(resp)
            };
        }

        public async Task<IPersonCreateBulkResp> CreateBulk(IPersonCreateBulkReq req)
        {
            if (req?.People == null || !req.People.Any())
            {
                return null;
            }

            var createdPeople = new List<PersonModel>();
            foreach (var person in req.People)
            {
                var personModel = this.mapper.Map<PersonModel>(person);
                var resp = await this.personRepository.CreateOrUpdatePerson(personModel);

                if (resp == null)
                {
                    // log failed 
                }
                
                createdPeople.Add(resp);
            }

            // second run for builk person creation to assign person connections
            foreach (var person in createdPeople.Where(person => person.RequiresSecondRun))
            {
                var personModel = this.mapper.Map<PersonModel>(person);
                var resp = await this.personRepository.CreateOrUpdatePerson(personModel);

                if (resp == null)
                {
                    // log failed 
                }
            }


            return new PersonCreateBulkResp()
            {
                People = this.mapper.Map<IEnumerable<PersonModel>, IEnumerable<Person>>(createdPeople)
            };
        }

        public async Task<IPersonGetResp> GetPerson(IPersonGetReq req)
        {
            throw new NotImplementedException();
        }
    }
}
