using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateSolutionDto
    {
        public string Solution { get; set; }
        public bool IsTrue { get; set; }
        public long Question_idQuestion { get; set; }

        
        public CreateSolutionDto(string solution, bool istrue,long question_idQuestion)
        {
            this.Solution = solution;
            this.IsTrue = istrue;
            this.Question_idQuestion = question_idQuestion;
        }

    }
}
