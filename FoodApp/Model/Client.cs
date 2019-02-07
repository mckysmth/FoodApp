using System;
using MongoDB.Driver;

namespace FoodApp.Model
{
    public static class Client
    {
        static MongoClient mongoClient = new MongoClient();
        public static IMongoDatabase database = mongoClient.GetDatabase("FoodApp");

        public static IMongoCollection<User> GetUserCollection()
        {
            IMongoCollection<User> collection = database.GetCollection<User>("Users");

            return collection;
        }

    }
}
