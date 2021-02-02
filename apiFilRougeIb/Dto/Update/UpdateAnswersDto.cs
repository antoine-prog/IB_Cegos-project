using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Update
{
    public class UpdateAnswersDto
    {
        public UpdateAnswersDto(string answer, bool result, bool isCreated)
        {
            Answer = answer;
            Result = result;
            IsCreated = isCreated;
        }

        public string Answer { get; set; }

        public bool Result { get; set; }
        public bool IsCreated { get; set; }

        
    }
}
