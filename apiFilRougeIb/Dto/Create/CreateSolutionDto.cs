using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateSolutionDto
    {
        public string Solution { get; set; }
        public long Question_idquestion { get; set; }
        public CreateSolutionDto(string solution, long id_question)
        {
            this.Solution = solution;
            this.Question_idquestion = id_question;
        }

    }
}
