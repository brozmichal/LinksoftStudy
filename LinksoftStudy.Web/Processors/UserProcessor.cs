using LinksoftStudy.Services.Interfaces;
using LinksoftStudy.Services.Models;
using LinksoftStudy.Web.Interfaces;
using LinksoftStudy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksoftStudy.Web.Processors
{
    public class UserProcessor : IUserProcessor
    {
        private readonly IUserService userService;

        public UserProcessor(
                IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IEnumerable<Interfaces.IUser>> GetUsers()
        {
            var resp = await this.userService.GetUsers(new UserGetMultipleReq());
            if (resp == null)
            {
                // log
                return null;
            }

            return resp.Users
                .Select(user => new Models.User()
                {
                    UserId = user.UserId
                });
        }

         public async Task<IUserStatistics> GetUsersStatistics()
        {
            var resp = await this.userService.GetStatistics();
            if (resp == null)
            {
                return null;
            }

            var result = new UserStatistics()
            {
                AverageFriendshipsPerUser = resp.UserStatistics.Count() > 0 
                    ? (int)resp.UserStatistics?.Average(us => us.TotalFriends) 
                    : 0,
                TotalUsers = resp.TotalUsers
            };

            return result; 
        }
    }
}