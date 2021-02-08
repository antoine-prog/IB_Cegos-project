using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Quiz
    {
        List<Questions> questions = new List<Questions>();
        public long IdQuiz { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
          
        public long User_idUser { get; set; }

        public Quiz() { }

        public Quiz(List<Questions> questions,long idQuiz, string name, string theme, long user_idUser)
        {
            this.questions = questions;
            IdQuiz = idQuiz;
            Name = name;
            Theme = theme;
            User_idUser = user_idUser;
        }
        
        public void ShowThisQuiz(User user, long idQuiz) { }
        public  void ShowQuiz() { }
    }
}
