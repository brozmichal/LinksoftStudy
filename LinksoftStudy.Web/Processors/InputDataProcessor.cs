using LinksoftStudy.Common.Interfaces;
using LinksoftStudy.Services.Interfaces;
using LinksoftStudy.Services.Models;
using LinksoftStudy.Web.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksoftStudy.Web.Processors
{
    public class InputDataProcessor : IInputDataProcessor
    {
        private readonly IPersonService personService;

        private readonly IInputDataService inputDataService;

        public InputDataProcessor(
                IPersonService personService,
                IInputDataService inputDataService)
        {
            this.personService = personService;
            this.inputDataService = inputDataService;
        }

        public async Task<bool> Process(string content)
        {
            // parsing uploaded file from filesystem
            // var contacts = this.inputContactService.ProcessInputFile(filePath);

            // parsing uploaded file content
            var contacts = this.inputDataService.ProcessContent(content);

            // first run to add everyone into db
            var people = new List<string>();
            foreach (var contact in contacts)
            {
                people.Add(contact.ContactPrimary);
                people.Add(contact.ContactSecondary);
            }

            var req = new PersonCreateBulkReq()
            {
                People = people
                .Distinct()
                .Select(person => new Person()
                {
                    PersonId = person
                })
            };

            var resp = await this.personService.CreateBulk(req);

            // second run to map contacts
            //var req = new PersonCreateBulkReq()
            //{
            //    People = contacts.Select(contact => new Person()
            //    {
            //        PersonId = contact.ContactPrimary,
            //        ContactId = contact.ContactSecondary
            //    })
            //};

            return resp != null
                ? true
                : false;
        }
    }
}