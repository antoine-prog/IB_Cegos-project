using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Quizz_Has_Question
    {
        public long quizz_idQuizz { get; set; }
        public long question_idQuestion { get; set; }
        public Quizz_Has_Question() { }

        public Quizz_Has_Question(long quizz_idQuizz, long question_idQuestion)
        {
            this.quizz_idQuizz = quizz_idQuizz;
            this.question_idQuestion = question_idQuestion;
        }
    }
}
