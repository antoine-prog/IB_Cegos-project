using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class User
    {
        public long? IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCreator { get; set; }

        public User() { }
        public User(string firstName, string lastName, string username, string adress, string mail, string password, bool isAdmin, bool isCreator, long? idUser = null)
        {
            IdUser = idUser;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Adress = adress;
            Mail = mail;
            Password = password;
            IsAdmin = isAdmin;
            IsCreator = isCreator;
        }


    }
}