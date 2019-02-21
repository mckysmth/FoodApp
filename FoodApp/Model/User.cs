﻿using System;
using SQLite;

namespace FoodApp.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        public User()
        {
        
        }

        public User(string firstName, string lastName, string email, string password, DateTime dob, float height, float weight)
        {
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