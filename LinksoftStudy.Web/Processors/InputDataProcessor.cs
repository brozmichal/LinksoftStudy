using AutoMapper;
using LinksoftStudy.Common.Interfaces;
using LinksoftStudy.Common.Models;
using LinksoftStudy.Services.Interfaces;
using LinksoftStudy.Services.Models;
using LinksoftStudy.Web.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LinksoftStudy.Web.Processors
{
    public class InputDataProcessor : IInputDataProcessor
    {
        private readonly IPersonService personService;

        private readonly IInputDataService inputDataService;

        private readonly IMapper mapper;

        public InputDataProcessor(
                IPersonService personService,
                IInputDataService inputDataService,
                IMapper mapper)
        {
            this.personService = personService;
            this.inputDataService = inputDataService;
            this.mapper = mapper;
        }

        public async Task<bool> Process(string content)
        {
            // parsing uploaded file from filesystem
            // var contacts = this.inputContactService.ProcessInputFile(filePath);

            // parsing uploaded file content
            var contacts = this.inputDataService.ProcessContent(content);

            // first run to add everyone into db
            //var people = new List<string>();
            //foreach (var contact in contacts)
            //{
            //    people.Add(contact.ContactPrimary);
            //    people.Add(contact.ContactSecondary);
            //}

            //var req = new PersonCreateBulkReq()
            //{
            //    People = people
            //    .Distinct()
            //    .Select(person => new Person()
            //    {
            //        PersonId = person
            //    })
            //};

            //second run to map contacts
            var req = new PersonCreateBulkReq()
            {
                People = this.mapper.Map<IEnumerable<ContactModel>, IEnumerable<Person>>(contacts.Select(contact => (ContactModel)contact))
            };

            var resp = await this.personService.CreateBulk(req);

            return resp != null
                ? true
                : false;
        }
    }
}