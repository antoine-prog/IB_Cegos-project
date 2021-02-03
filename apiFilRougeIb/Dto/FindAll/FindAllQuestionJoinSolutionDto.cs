using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuestionJoinSolutionDto : FindAllQuestionsDto
    {
        public FindAllQuestionJoinSolutionDto(Models.Question question) : 
            base(question.Title,  question.Level_idLevel, question.IdQuestion)
        {
            this.Solution = new Repositories.SolutionRepository(new Utils.QueryBuilder())
                .FindSolution((long)question.IdQuestion).solution;            
        }        
        public string Solution { get; set; }
    }
}
