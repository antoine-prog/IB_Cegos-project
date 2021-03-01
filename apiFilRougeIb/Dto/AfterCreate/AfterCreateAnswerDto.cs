using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.AfterCreate
{
    public class AfterCreateAnswerDto
    {
        public long? IdAnswer { get; set; }
        public string Answer { get; set; }
        public bool? Result { get; set; }
        public bool IsCreated { get; set; }


        public AfterCreateAnswerDto(string answer, bool isCreated, bool? result, long? IdAnswer = null)
        {
            this.IdAnswer = IdAnswer;
            this.Answer = answer;
            this.Result = result;
            this.IsCreated = isCreated;
        }
        

    }
}
