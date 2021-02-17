using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class User
    {

//Attributs
        public long? IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCreator { get; set; }
        public List<Quiz> ListQuiz { get; set; } = new List<Quiz>();
        public List<Answer> ListReponses { get; set; } = new List<Answer>();

//Construtors
        public User() { }

        public User(string firstName, string lastName, string username, string adress, string mail, string password, bool isAdmin, bool isCreator, List<Quiz> listQuiz, List<Answer> listReponses, long? idUser)
        {
            this.IdUser = idUser;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Adress = adress;
            this.Mail = mail;
            this.Password = password;
            this.IsAdmin = isAdmin;
            this.IsCreator = isCreator;
            this.ListQuiz = listQuiz;
            this.ListReponses = listReponses;
        }

//Methods
        /// <summary>
        /// demande le mdp d'un user, s'il correspond bien au mdp du user dans la base de donné return true
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool Identification(string username)
        {
            //Get username dans la base de donnée

            //S'il existe dans la base de données {
                //récupere les attributs par rapport à cet username
                // assigne à  l'user les attributs récuperer depuis la base de donnée
                // return true
            //}
            // S'il n'existe pas dans la basse de données
            return false;
        }

        /// <summary>
        /// connection d'un user
        /// </summary>
        public void UserConnection()
        {
            // demande le mot de passe pour username 
            //Si c'est le bon mot de passe {
            Console.WriteLine("Vous etes connecté");

            //Si c'est le mauvais mot de passe
            Console.WriteLine("Mauvais mot de passe, veuillez ressayer");
            //UserConnection();
        }

        /// <summary>
        /// Demande l'ensemble des données demandées pour l'inscription d'un user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public void UserCreateUsername(string username)
        {
            Console.WriteLine("Saisissez votre Prénom");
            this.FirstName = Console.ReadLine();
            Console.WriteLine("Saisissez votre nom");
            this.LastName = Console.ReadLine();
            this.Username = username;
            Console.WriteLine("Saisissez votre adresse");
            this.Adress = Console.ReadLine();
            Console.WriteLine("Saisissez votre adresse mail");
            this.Mail = Console.ReadLine();
            Console.WriteLine("Saisissez votre mot de passe");
            this.Password = Console.ReadLine();
            Console.WriteLine("Vous venez de créer votre utilisateur");
            Console.WriteLine("----------------------------------------------------------------");
        }

        public void ShowQuiz()
        {
            if (ListQuiz.Count == 0)
            {
                Console.WriteLine("Vous n'avez pour le moment aucun questionnaires de crées");
            }
            else
            {
                //for each de tous les quizz que l'utilisateur (créateur) à crée
                foreach (Quiz q in ListQuiz)
                {
                    Console.WriteLine($"{q.Name} [{q.Theme}] (id={q.IdQuiz}");
                }

                //On demande s'il veut voir un quizz en particulier
                Console.WriteLine("quel questionanire voulez-vous voir ? (rentrer l'id)");
                int choixQuiz = Int32.Parse(Console.ReadLine());

                //on Vérifie que l'id que l'utilisateur rentre existe bien dans sa collection
                foreach (Quiz q in ListQuiz)
                {
                    //id à été trouvé dans la collection
                    if (choixQuiz == q.IdQuiz)
                    {
                        q.ShowQuiz();
                    }
                }

                //On demande à nouveau ce que l'utilisateur veut faire
                Console.WriteLine("Que souhaitez vous faire maintenant ?");
                Start.SelectMode();
            }
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

        /// <summary>
        /// Affiche les données utilisateur
        /// </summary>
        public static void ShowData() 
        {

        }

        /// <summary>
        /// L'utilisateur peut modifier ses données utilisateurs
        /// </summary>
        public static void ModifyData()
        {

        }

    }
}
