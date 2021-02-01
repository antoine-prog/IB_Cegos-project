using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Solution
    {
        public long? IdSolution { get; set; }
        public string Solution_ { get; set; }
        
        public long Question_idquestion { get; set; }
        public Solution() { }
        public Solution(string solution, long id_question,  long? IdSolution = null)
        {
            this.IdSolution = IdSolution;
            this.Solution_ = solution;
            this.Question_idquestion = id_question;
        }

    }
}
