using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateAnswerDto
    {
       
        public string Answer_ { get; set; }
        public bool Result { get; set; }
        public CreateAnswerDto(string answer_, bool result)
        {
            Answer_ = answer_;
            Result = result;
        }
    }
}
