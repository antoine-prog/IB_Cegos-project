using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllAnswersDto
    {
        public long? IdAnswer { get; set; }
        public string? Answer { get; set; }
        public bool? Result { get; set; }

        public FindAllAnswersDto(string answer, bool? result = null, long? idAnswer = null)
        {
            IdAnswer = idAnswer;
            Answer = answer;
            Result = result;
        }
    }
}
