using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateSolutionDto
    {
        public string Solution { get; set; }
        public long Question_idQuestion { get; set; }

        
        public CreateSolutionDto(string solution, long question_idQuestion)
        {
            this.Solution = solution;
            this.Question_idQuestion = question_idQuestion;
        }

    }
}
