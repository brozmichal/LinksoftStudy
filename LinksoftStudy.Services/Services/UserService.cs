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
    public class UserService : IUserService
    {
        private readonly IMapper mapper;

        private readonly IUserRepository userRepository;

        public UserService(
            IMapper mapper,
            IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<IUserGetMultipleResp> GetUsers(IUserGetMultipleReq req)
        {
            var resp = await this.userRepository.GetUsers(req.Skip, req.Take);

            var result = new UserGetMultipleResp();
            if (resp == null)
            {
                result.Users = Enumerable.Empty<User>();
            };

            result.Users = resp.Select(user => this.mapper.Map<User>(user)).AsEnumerable();

            return result;
        }

        public async Task<IUserCreateOrUpdateResp> CreateOrUpdateUser(IUserCreateOrUpdateReq req)
        {
            if (string.IsNullOrEmpty(req?.User.UserId))
            {
                return null;
            }

            var dataModel = mapper.Map<UserModel>(req);

            var resp = await this.userRepository.CreateOrUpdateUser(dataModel);
            if (resp == null)
            {
                // log error
                return null;
            }

            return new UserCreateOrUpdateResp()
            {
                User = this.mapper.Map<User>(resp)
            };
        }

        public async Task<IUserCreateBulkResp> CreateBulk(IUserCreateBulkReq req)
        {
            if (req?.Users == null || !req.Users.Any())
            {
                return null;
            }

            var createdUsers = new List<UserModel>();
            foreach (var user in req.Users)
            {
                var userModel = this.mapper.Map<UserModel>(user);
                var resp = await this.userRepository.CreateOrUpdateUser(userModel);

                if (resp == null)
                {
                    // log failed 
                }

                createdUsers.Add(resp);
            }

            // second run for builk user creation to assign user connections
            foreach (var user in createdUsers.Where(user => user.RequiresSecondRun))
            {
                var userModel = this.mapper.Map<UserModel>(user);
                var resp = await this.userRepository.CreateOrUpdateUser(userModel);

                if (resp == null)
                {
                    // log failed 
                }
            }

            return new UserCreateBulkResp()
            {
                Users = this.mapper.Map<IEnumerable<UserModel>, IEnumerable<User>>(createdUsers)
            };
        }

        public async Task<IUserGetStatisticsResp> GetStatistics()
        {
            var resp = await this.userRepository.GetUsersStatistics();
            if (resp == null)
            {
                return null;
            }

            var result = new UserGetStatisticsResp()
            {
                UserStatistics = resp.Users.Select(user => new UserStatistic()
                {
                    User = new User() {
                       UserId = user.User.UserId
                    },
                    TotalFriends = user.TotalFriendships
                }).ToList(),
                TotalUsers = resp.TotalUsers
            };

            return result;
        }

        public async Task<IUserGetResp> GetUser(IUserGetReq req)
        {
            throw new NotImplementedException();
        }
    }
}
