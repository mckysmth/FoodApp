using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FoodApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodApp.Services
{
    public static class AzureService
    {
        public async static System.Threading.Tasks.Task InsertGroupAsync(Group group)
        {
            await App.MobileService.GetTable<Group>().InsertAsync(group);
        }

        public async static Task<Group> GetGroup(string GroupCode)
        {
            return (await App.MobileService.GetTable<Group>().Where(g => g.GroupCode == GroupCode).ToListAsync()).FirstOrDefault();
        }

        public async static Task<List<UserGroup>> GetAllUsersInGroup(Group group)
        {
            return await App.MobileService.GetTable<UserGroup>().Where(ug => ug.GroupId == group.Id).ToListAsync();
        }

        public async static System.Threading.Tasks.Task JoinGroup(Group group, FoodUser user)
        {
            UserGroup userGroup = new UserGroup
            {
                GroupId = group.Id,
                UserID = user.Id
            };

            await App.MobileService.GetTable<UserGroup>().InsertAsync(userGroup); ;
        }

        public async static System.Threading.Tasks.Task<FoodUser> GetUserByEmail(FoodUser user)
        {

            return (await App.MobileService.GetTable<FoodUser>().Where(u => u.Email == user.Email).ToListAsync()).FirstOrDefault();
        }

        public async static System.Threading.Tasks.Task InsertUser(FoodUser user)
        {
            await App.MobileService.GetTable<FoodUser>().InsertAsync(user);
        }
    }

}
