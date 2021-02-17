using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Start
    {
    //Attributs
        static User user = new User();

    //Constuctors
        public Start() { }

    //Methods

        /// <summary>
        /// Demarre le quizz, demande à l'utilisateur de se connecter
        /// </summary>
        public static void StartQuiz()
        {
            Console.WriteLine("Identidiez-vous");
            string username = Console.ReadLine();
            //verifie si l'username existe déjà dans la bdd
            user.Identification(username);
            if (user.Identification(username) == true)
            {
                Console.WriteLine("Utilisateur trouvé : mdp ?");
                //si oui lance la méthode de connection et demande son mdp
                user.UserConnection();
            }
            else 
            {
                //si non demande à l'utilisateur de sinscrire
                Console.WriteLine("Cet username n'existe pas. Créez un username");
                user.UserCreateUsername(username); 
            }

            //une fois la connection faite, demande au créateur ce qu'il veut faire 
            Console.WriteLine("Que souhaitez vous faire ?");
            SelectMode();    
        }     


        /// <summary>
        /// demande à l'utilisateur l'action qu'il veut faire
        /// </summary>
        public static void SelectMode() 
        {
            //On demande à l'utilisateur de choisir sa prochiane action
            Console.WriteLine("Choisissez un mode");
            Console.WriteLine("[ S ] - Voir les questionnaires");
            Console.WriteLine("[ C ] - Créer un questionnaire");
            Console.WriteLine("[ P ] - voir et modifier votre profil");
            string Choix = Console.ReadLine();
            //L'utilisateur veut voir ses questionnaires
            if (Choix.ToLower().Equals("s")) 
            { 
                Console.WriteLine("Liste de vos questionnaires");
                user.ShowQuiz();
            }
            //L'utilisateur veut créer un nouveau questionnaire
            else if (Choix.ToLower().Equals("c")) 
            { 
                Console.WriteLine("Vous-pouvez créer votre quiz"); 
                user.CreateQuiz();             
            }
            else if (Choix.ToLower().Equals("P"))
            {
                Console.WriteLine("Voici votre profil utilisateur");
                user.ShowData();
            }
            else 
            { 
                Console.WriteLine("Ce mode n'existe pas. Choisissez un mode");
                SelectMode();
            }

        }
        
       
    }
}
