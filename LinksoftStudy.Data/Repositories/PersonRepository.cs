using LinksoftStudy.Data.Interfaces;
using LinksoftStudy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinksoftStudy.Data.Repositories
{
    public class PersonRepository : BaseRepository<PersonEntity>, IPersonRepository
    {
        public PersonRepository(Context context) : base(context)
        {
        }

        public async Task<PersonModel> CreateOrUpdatePerson(PersonModel person)
        {
            try
            {
                var personEntity = context.Persons
                    .Where(entity => entity.PersonId.Equals(person.PersonId))
                    .Include(x => x.Contacts)
                    .FirstOrDefault();

                if (personEntity == null)
                {
                    personEntity = new PersonEntity();
                    this.CreatePerson(personEntity, person);
                }
                else
                {
                    this.UpdatePerson(personEntity, person);
                }

                await context.SaveChangesAsync();

                return new PersonModel()
                {
                    PersonId = personEntity.PersonId,
                    ContactId = person.ContactId,
                    RequiresSecondRun = person.RequiresSecondRun
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PersonModel>> GetPeople(int skip, int take)
        {
            try
            {
                var people = GetAll();
                if (people == null || !people.Any())
                {
                    return Enumerable.Empty<PersonModel>();
                }

                var result = people.Select(person => new PersonModel()
                {
                    PersonId = person.PersonId
                });

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<PersonModel> GetPerson(string personId)
        {
            try
            {
                var person = context.Persons
                    .Include(table => table.Contacts)
                    .Where(person => person.PersonId.Equals(personId))
                    .FirstOrDefault();

                if (person == null)
                {
                    return null;
                }

                return new PersonModel()
                {
                    PersonId = person.PersonId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        private void UpdatePerson(PersonEntity personEntity, PersonModel person)
        {
            personEntity.PersonId = person.PersonId;
            personEntity.DateUpdated = DateTime.UtcNow;
            this.TryAssignContact(personEntity, person);
            context.Persons.Update(personEntity);
        }

        private void CreatePerson(PersonEntity personEntity, PersonModel person)
        {
            personEntity.PersonId = person.PersonId;
            personEntity.DateCreated = DateTime.UtcNow;
            this.TryAssignContact(personEntity, person);
            context.Persons.Add(personEntity);
        }


        private void TryAssignContact(PersonEntity personEntity, PersonModel person)
        {
            var contact = context.Persons
                    .Where(entity => entity.PersonId == person.ContactId)
                    .FirstOrDefault();

            // contact person does not exist
            if (contact == null)
            {
                person.RequiresSecondRun = true;
                return;
            }

            try
            {
                var connectionExists = personEntity.Contacts
                    .Any(c => c.Contact.Id == contact.Id);
                if (connectionExists)
                {
                    return;
                }

                personEntity.Contacts.Add(new ContactContacteeEntity
                {
                    Contactee = personEntity,
                    ContacteeId = personEntity.Id,
                    Contact = contact,
                    ContactId = contact.Id,
                    DateCreated = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception occured in {nameof(TryAssignContact)}. Ex: {ex.Message}");
            }
        }
    }
}
