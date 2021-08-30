using LinksoftStudy.Data.Interfaces;
using LinksoftStudy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksoftStudy.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<UserModel>> CreateUsers(IEnumerable<UserModel> users)
        {
            try
            {
                var processedUsers = new List<UserModel>();
                UserEntity userEntity;
                foreach (var user in users)
                {
                    userEntity = context.Users
                    .Where(entity => entity.UserId == user.UserId)
                    .Include(x => x.Contacts)
                    .FirstOrDefault();

                    if (userEntity != null)
                    {
                        continue;
                    }

                    userEntity = new UserEntity();
                    this.CreateUser(userEntity, user);
                    await context.SaveChangesAsync();

                    processedUsers.Add(new UserModel()
                    {
                        UserId = userEntity.UserId,
                        ContactId = user.ContactId,
                        RequiresSecondRun = user.RequiresSecondRun
                    });
                }

                foreach (var processedUser in processedUsers.Where(pu => pu.RequiresSecondRun))
                {
                    userEntity = context.Users
                    .Where(entity => entity.UserId == processedUser.UserId)
                    .Include(x => x.Contacts)
                    .FirstOrDefault();

                    this.TryAssignContact(userEntity, processedUser);
                    await context.SaveChangesAsync();
                }

                return processedUsers;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't create entities: {ex.Message}");
            }

        }

        public async Task<UserModel> CreateOrUpdateUser(UserModel user)
        {
            try
            {
                var userEntity = context.Users
                    .Where(entity => entity.UserId.Equals(user.UserId))
                    .Include(x => x.Contacts)
                    .FirstOrDefault();

                if (userEntity == null)
                {
                    userEntity = new UserEntity();
                    this.CreateUser(userEntity, user);
                }
                else
                {
                    this.UpdateUser(userEntity, user);
                }

                await context.SaveChangesAsync();

                return new UserModel()
                {
                    UserId = userEntity.UserId,
                    ContactId = user.ContactId,
                    RequiresSecondRun = user.RequiresSecondRun
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserModel>> GetUsers(int skip, int take)
        {
            try
            {
                var users = GetAll();
                if (users == null || !users.Any())
                {
                    return Enumerable.Empty<UserModel>();
                }

                var result = users.Select(user => new UserModel()
                {
                    UserId = user.UserId
                });

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<UserModel> GetUser(string userId)
        {
            try
            {
                var user = context.Users
                    .Include(table => table.Contacts)
                    .Where(us => us.UserId.Equals(userId))
                    .FirstOrDefault();

                if (user == null)
                {
                    return null;
                }

                return new UserModel()
                {
                    UserId = user.UserId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public async Task<UserStatisticsModel> GetUsersStatistics()
        {
            var users = GetAll();

            var result = new UserStatisticsModel();
            if (users == null)
            {
                result.Users = Enumerable.Empty<UserStatisticModel>();
                result.TotalUsers = 0;
                return result;
            }

            result.Users = users
                .GroupBy(u => u.UserId)
                .Select(us => new UserStatisticModel()
                {
                    User = new UserModel()
                    {
                        UserId = us.Key
                    },
                    TotalFriendships = us.Select(c => c.Contacts).Count()
                });

            result.TotalUsers = users.GroupBy(u => u.UserId).Count();

            return result;
        }

        private void UpdateUser(UserEntity userEntity, UserModel user)
        {
            userEntity.UserId = user.UserId;
            userEntity.DateUpdated = DateTime.UtcNow;
            this.TryAssignContact(userEntity, user);
            context.Users.Update(userEntity);
        }

        private void CreateUser(UserEntity userEntity, UserModel user)
        {
            userEntity.UserId = user.UserId;
            userEntity.DateCreated = DateTime.UtcNow;
            this.TryAssignContact(userEntity, user);
            context.Users.Add(userEntity);
        }


        private void TryAssignContact(UserEntity userEntity, UserModel user)
        {
            var contact = context.Users
                    .Where(entity => entity.UserId == user.ContactId)
                    .FirstOrDefault();

            // contact person does not exist - might be created in running sequence
            if (contact == null)
            {
                user.RequiresSecondRun = true;
                return;
            }

            try
            {
                var connectionExists = userEntity.Contacts
                    .Any(c => c.Contact.Id == contact.Id);
                if (connectionExists)
                {
                    return;
                }

                userEntity.Contacts.Add(new ContactContacteeEntity
                {
                    Contactee = userEntity,
                    ContacteeId = userEntity.Id,
                    Contact = contact,
                    ContactId = contact.Id,
                    DateCreated = DateTime.UtcNow
                });

                user.RequiresSecondRun = false;
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception occured in {nameof(TryAssignContact)}. Ex: {ex.Message}");
            }
        }
    }
}
