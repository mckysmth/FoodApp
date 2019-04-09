using System.Collections.Generic;
using System.Linq;
using FoodApp.Model;
using SQLite;

namespace FoodApp.Services
{
    public class SQLService
    {

        SQLiteConnection connection;

        public void InsertUser(FoodUser user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<FoodUser>();

                connection.Insert(user);

            }
        }


        public List<FoodUser> GetUserList(FoodUser user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<FoodUser>();

                List<FoodUser> users = connection.Table<FoodUser>().ToList();

                return users;
            }
        }

        public FoodUser GetUserByEmail(FoodUser user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<FoodUser>();

                List<FoodUser> users = connection.Table<FoodUser>().ToList();

                FoodUser returnUser = users.FirstOrDefault(u => u.Email == user.Email);

                return returnUser;
            }
        }
    }
}
