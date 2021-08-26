using LinksoftStudy.Data.Interfaces;
using LinksoftStudy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    .FirstOrDefault();

                Task<PersonEntity> result = default;
                if (personEntity != null)
                {
                    result = this.UpdatePerson(personEntity, person);
                }

                result = this.CreatePerson(person);

                return new PersonModel()
                {
                    PersonId = result.Result.PersonId
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
                }).AsEnumerable();

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

        private async Task<PersonEntity> UpdatePerson(PersonEntity personEntity, PersonModel person)
        {
            personEntity.PersonId = person.PersonId;
            personEntity.DateUpdated = DateTime.UtcNow;
            //this.TryAssignContact(personEntity, person.ContactId);

            return await UpdateAsync(personEntity);
        }

        private async Task<PersonEntity> CreatePerson(PersonModel person)
        {
            var personToAdd = new PersonEntity();
            personToAdd.PersonId = person.PersonId;
            personToAdd.DateCreated = DateTime.UtcNow;
            //this.TryAssignContact(personToAdd, person.ContactId);

            return await AddAsync(personToAdd);
        }


        private void TryAssignContact(PersonEntity person, string contacteeId)
        {
            var contact = context.Persons
                    .Where(entity => entity.PersonId.Equals(person.PersonId))
                    .FirstOrDefault();

            if (contact != null)
            {
                person.Contact.Add(new ContactContacteeEntity()
                {
                    ContactId = person.Id,
                    Contact = person,
                    ContacteeId = contact.Id,
                    Contactee = contact
                });
            }
        }
    }
}
