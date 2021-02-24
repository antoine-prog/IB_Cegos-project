using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Quiz
    {
        public long IdQuiz { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public User Creator { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        public List<User> Participants { get; set; } = new List<User>();

        public Quiz() { }

        public Quiz(long idQuiz, string name, string theme, User creator, List<Question> questions, List<User> participants)
        {
            this.IdQuiz = idQuiz;
            this.Name = name;
            this.Theme = theme;
            this.Creator = creator;
            this.Questions = questions;
            this.Participants = participants;
        }
        
        /// <summary>
        /// Affiche un questionnaire en détail et les participants du questionnaire
        /// </summary>
        public  void ShowQuiz() {
           
            Console.WriteLine($"{this.Name} [{this.Theme}] (id={this.IdQuiz}");

            foreach(User p in Participants)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName}], mail : {p.Mail}");
            }


            
        }
    }
}
