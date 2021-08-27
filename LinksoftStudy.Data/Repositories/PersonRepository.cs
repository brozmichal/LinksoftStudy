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
                    .Include(table => table.Contacts)
                    .Where(entity => entity.PersonId.Equals(person.PersonId))
                    .FirstOrDefault();

                if (personEntity == null)
                {
                    this.CreatePerson(person);
                }
                else
                {
                    this.UpdatePerson(personEntity, person);
                }

                var result = await context.SaveChangesAsync();

                return new PersonModel()
                {
                    PersonId = personEntity.PersonId
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
            this.TryAssignContact(personEntity, person.ContactId);
        }

        private void CreatePerson(PersonModel person)
        {
            var personToAdd = new PersonEntity();
            personToAdd.PersonId = person.PersonId;
            personToAdd.DateCreated = DateTime.UtcNow;
            this.TryAssignContact(personToAdd, person.ContactId);
        }


        private void TryAssignContact(PersonEntity person, string contactId)
        {
            var contact = context.Persons
                    .Where(entity => entity.PersonId.Equals(contactId))
                    .FirstOrDefault();

            // contact person does not exist
            if (contact == null)
            {
                return;
            }

            try
            {
                var connectionExists = person.Contacts
                    .Any(con => con.ContacteeId == contact.Id);

                if (connectionExists)
                {
                    return;
                }

                var contactToAdd = new ContactContacteeEntity()
                {
                    ContactId = contact.Id,
                    ContacteeId = person.Id,
                    DateCreated = DateTime.UtcNow
                };

                context.Contacts.Add(contactToAdd);
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception occured in {nameof(TryAssignContact)}. Ex: {ex.Message}");
            }
        }
    }
}
