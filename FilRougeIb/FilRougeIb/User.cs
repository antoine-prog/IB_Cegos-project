using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class User
    {
        List<Quiz> quiz = new List<Quiz>();
        public long? IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCreator { get; set; }
        public long Level_idLevel { get; set; }

        public User() { }

        public User(List<Quiz> quiz, long? idUser, string firstName, string lastName, string username, string adress, string mail, string password, bool isAdmin, bool isCreator, long level_idLevel)
        {
            this.quiz = quiz;
            IdUser = idUser;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Adress = adress;
            Mail = mail;
            Password = password;
            IsAdmin = isAdmin;
            IsCreator = isCreator;
            Level_idLevel = level_idLevel;
        }

    }
}
