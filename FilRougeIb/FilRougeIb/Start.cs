using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Start
    {
        static User user = new User();
        public Start() { }
        public static void StartQuiz()
        {
            
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
                 user = user.UserCreateUsername(username); 
            }

            Console.WriteLine("Voulez-vous voir un quiz ou créer un quiz ?");
            SelectMode();    
        }

        public static void UserConnection() 
        { }
        
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
                user.CreateQuiz();             
            }
            else 
            { 
                Console.WriteLine("Ce mode n'existe pas. Choisissez un mode");
                SelectMode();
            }

        }
        
        public static void ShowData() { }
    }
}
