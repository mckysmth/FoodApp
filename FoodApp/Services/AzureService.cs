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

        public async static Task<List<FoodUser>> GetAllUsersInGroup(Group group)
        {
            List<FoodUser> users = new List<FoodUser>();

            List<UserGroup> userGroup = await App.MobileService.GetTable<UserGroup>().Where(ug => ug.GroupId == group.Id).ToListAsync();

            foreach (var item in userGroup)
            {
                FoodUser user = (await App.MobileService.GetTable<FoodUser>().Where(u => u.Id == item.UserID).ToListAsync()).FirstOrDefault();
                if (user != null)
                {
                    users.Add(user);
                }
            }

            return users;

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

        public async static System.Threading.Tasks.Task InsertPlace(Place place)
        {
            await App.MobileService.GetTable<Place>().InsertAsync(place);
        }
    }

}
