using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.AfterCreate
{
    public class AfterCreateSolutionDto
    {
        public long? IdSolution { get; set; }
        public bool IsCreated { get; set; }
        public string Solution { get; set; }
        public long Question_idquestion { get; set; }
        public AfterCreateSolutionDto(string solution, long id_question, bool isCreated, long? IdSolution = null)
        {
            this.IdSolution = IdSolution;
            this.Solution = solution;
            this.Question_idquestion = id_question;
            this.IsCreated = isCreated;
        }

    }
}
