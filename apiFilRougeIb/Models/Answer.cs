using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Answer
    {
        public long? IdAnswer { get; set; }
        public string answer { get; set; }

        public bool? Result { get; set; }
        public Answer() { }

        public Answer( string answer, bool? result,long? idAnswer=null)
        {
            IdAnswer = idAnswer;
            answer = answer;
            Result = result;
        }
    }
}
