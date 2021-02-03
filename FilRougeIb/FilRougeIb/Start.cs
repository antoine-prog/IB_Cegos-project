using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Start
    {
         public Start() { }
        public static void StartQuiz()
        {
            User user = new User();
            Console.WriteLine("Identidiez-vous");
            string username = Console.ReadLine();
            Identification(username);
            if (Identification(username) == true)
            {
                Console.WriteLine("Vous êtes connecté");
                UserConnection();
            }
            else 
            {
                Console.WriteLine("Cet username n'existe pas. Créez un username");
                 user = UserCreateUsername(username); 
            }

            Console.WriteLine("Voulez-vous voir un quiz ou créer un quiz ?");
            SelectMode();    
        }

        public static void UserConnection() 
        { }
        public static User UserCreateUsername(string username)
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
        public static bool Identification(string username) 
        {
            return false;
        }
        public static void SelectMode() 
        {
            Console.WriteLine("Choisissez un mode");
            Console.WriteLine("[ S ] - Voir un quiz");
            Console.WriteLine("[ C ] - Créer un quiz");
            string Choix = Console.ReadLine();
            if (Choix.ToLower() == "S") 
            { 
                Console.WriteLine("Bienvenu(e) sur votre quiz");
                ShowQuiz();
            }
            else if (Choix.ToLower() == "C") 
            { 
                Console.WriteLine("Vous-pouvez créer votre quiz"); 
                CreateQuizz();             
            }
            else 
            { 
                Console.WriteLine("Ce mode n'existe pas. Choisissez un mode");
                SelectMode();
            }

        }
        public static void ShowQuiz() { }
        public static void CreateQuizz() { }
        public static void ShowData() { }
    }
}
