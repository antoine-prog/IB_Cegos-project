using apiFilRougeIb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuestionJoinSolutionDto : FindAllQuestionsDto
    {
        public FindAllQuestionJoinSolutionDto(Question question) : 
            base(question.Title,  question.Level_idLevel, question.Comment,question.IdQuestion)
        {
            this.Solution = new Repositories.SolutionRepository(new Utils.QueryBuilder())
                .FindSolutionByQuestion((long)question.IdQuestion);            
        }        
        public List<Solution> Solution { get; set; }
    }
}
