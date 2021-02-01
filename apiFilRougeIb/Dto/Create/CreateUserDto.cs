using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCreator { get; set; }
        public long Level_idLevel { get; set; }

        public CreateUserDto(string firstName, string lastName, string username, string adress, string mail, string password, bool isAdmin, bool isCreator, long level_idLevel)
        {
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
