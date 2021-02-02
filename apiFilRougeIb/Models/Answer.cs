using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Answer
    {
        public long? IdAnswer { get; set; }
        public string Answer_ { get; set; }

        public bool Result { get; set; }
        public Answer() { }

        public Answer( string answer_, bool result,long? idAnswer=null)
        {
            IdAnswer = idAnswer;
            Answer_ = answer_;
            Result = result;
        }
    }
}
