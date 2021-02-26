using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Solution
    {
        public long? IdSolution { get; set; }
        public string solution { get; set; }
        
        public long Question_idQuestion { get; set; }
        public bool IsTrue { get; set; }
        public Solution() { }
        public Solution(string solution, bool istrue,long id_question,  long? IdSolution = null)
        {
            this.IdSolution = IdSolution;
            this.solution = solution;
            this.Question_idQuestion = id_question;
            this.IsTrue = istrue;
        }

    }
}
