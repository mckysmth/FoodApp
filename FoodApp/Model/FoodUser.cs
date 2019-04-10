using System;
using SQLite;

namespace FoodApp.Model
{
    public class FoodUser
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public Boolean IsPlaying { get; set; }

        public FoodUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public FoodUser(string firstName, string lastName, string email, string password, DateTime dob, float height, float weight)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Dob = dob;
            Height = height;
            Weight = weight;
        }
    }
}