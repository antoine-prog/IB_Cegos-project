using System;
using System.Collections.Generic;
using System.Text;

namespace FilRougeIb
{
    class Answer
    {
    //Attributs

        public long? IdAnswer { get; set; }
        public string AnswerText { get; set; }
        public bool Result { get; set; }
        public User Candidat { get; set; }
        public Question Question { get; set; }



        public Answer( string answerText, bool result, User candidat, Question question, long? idAnswer)
        {
            this.IdAnswer = idAnswer;
            this.AnswerText = answerText;
            this.Result = result;
            this.Candidat = candidat;
            this.Question = question;
        }

        //Constructors






    }








}
