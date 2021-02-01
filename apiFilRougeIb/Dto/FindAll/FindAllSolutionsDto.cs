using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllSolutionsDto
    {
        public long? IdSolution { get; set; }
        public string Solution { get; set; }
        public long Question_idquestion { get; set; }
        public FindAllSolutionsDto(string solution, long id_question, long? id=null)
        {
            this.IdSolution = id;
            this.Solution = solution;
            this.Question_idquestion = id_question;
        }


    }
}
