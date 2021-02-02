using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.AfterCreate
{
    public class AfterCreateAnswerDto
    {
        public AfterCreateAnswerDto(string answer, bool result, bool isCreated, long? IdAnswer = null)
        {
            this.IdAnswer = IdAnswer;
            Answer = answer;
            Result = result;
            IsCreated = isCreated;
        }
        public long? IdAnswer { get; set; }
        public string Answer { get; set; }

        public bool Result { get; set; }
        public bool IsCreated { get; set; }


    }
}
