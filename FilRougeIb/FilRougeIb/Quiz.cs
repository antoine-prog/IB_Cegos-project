using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Quiz
    {
        public long? IdQuiz { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public User Creator { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        public List<User> Participants { get; set; } = new List<User>();

        public Quiz() { }

        public Quiz( string name, string theme, User creator, List<Question> questions, long? idQuiz, List<User> participants)
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
        public void ShowthisQuiz(User user) {
           
            Console.WriteLine($"{this.Name} [{this.Theme}] (id={this.IdQuiz}");

            foreach(Question q in Questions)
            {
                Console.WriteLine($"{q.Title}");
                foreach(Solution s in q.Solutions)
                {
                    Console.WriteLine($" {s.SolutionText}, bonne réponse ? : {s.IsTrue}");
                }
            }

            user.ShowQuiz();

        
        }
    }
}
