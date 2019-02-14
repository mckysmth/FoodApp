using System;
using System.Security.Authentication;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Linq;
using MongoDB.Bson;
using FoodApp.Model;

namespace FoodApp.Services
{
    public class MongoService
    {
        string dbName = "FoodApp";
        string collectionName = "Users";

        IMongoCollection<User> userCollection;
        IMongoCollection<User> UserCollection
        {
            get
            {
                if (userCollection == null)
                {
                    // This will create or get the collection
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    userCollection = ConnectDB().GetCollection<User>(collectionName, collectionSettings);
                }
                return userCollection;
            }
        }

        public async Task InsertNewUser(User user)
        {
            await UserCollection.InsertOneAsync(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var allTasks = await UserCollection
                    .Find(new BsonDocument())
                    .ToListAsync();

                return allTasks;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }


        private IMongoDatabase ConnectDB()
        {
            // APIKeys.Connection string is found in the portal under the "Connection String" blade
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl("mongodb://food-app:UjsUsROtZnTaR7v2yM7bvW1nOWea68VwRLiJ6IaMbo4QvEctRpAVSv85pejGMBFmxwnus1LsmUjrTGhbVSUswQ==@food-app.documents.azure.com:10255/?ssl=true&replicaSet=globaldb")
            );

            settings.SslSettings =
                new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            // Initialize the client
            var mongoClient = new MongoClient(settings);

            // This will create or get the database
            var db = mongoClient.GetDatabase(dbName);

            return db;
        }

    }
}
