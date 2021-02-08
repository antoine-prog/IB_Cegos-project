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
        public User UserCreateUsername(string username)
        {
            User usercreate = new User();
            Console.WriteLine("Saisissez votre Prénom");
            usercreate.FirstName = Console.ReadLine();
            Console.WriteLine("Saisissez votre nom");
            usercreate.LastName = Console.ReadLine();
            usercreate.Username = username;
            Console.WriteLine("Saisissez votre adresse");
            usercreate.Adress = Console.ReadLine();
            Console.WriteLine("Saisissez votre adresse mail");
            usercreate.Mail = Console.ReadLine();
            Console.WriteLine("Saisissez votre mot de passe");
            usercreate.Password = Console.ReadLine();
            Console.WriteLine("Vous venez de créer votre utilisateur");
            return usercreate;
        }
        public Quiz CreateQuiz() 
        {
            Quiz quizcreated = new Quiz();
            Console.WriteLine("Nommez votre quiz ?");
            quizcreated.Name = Console.ReadLine();
            Console.WriteLine("Choisissez le thème de votre quiz ?");
            quizcreated.Theme = Console.ReadLine();
            Console.WriteLine("Combien de questions voulez vous ?");
            int nbrdequestions = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < nbrdequestions; i++) { }
            Console.WriteLine("Vous avez créer " + nbrdequestions + " questions ?");
            return quizcreated;


        }

    }
}
