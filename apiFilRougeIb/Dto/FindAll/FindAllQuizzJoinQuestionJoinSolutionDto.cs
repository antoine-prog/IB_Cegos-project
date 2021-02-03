using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuizzJoinQuestionJoinSolutionDto : FindAllQuizzDto
    {
        public List<FindAllQuestionJoinSolutionDto> listquestionsolution { get; set; }

        public FindAllQuizzJoinQuestionJoinSolutionDto(FindAllQuizzDto quizz) : base(quizz.Name, quizz.User_idUser, quizz.IdQuizz)
        {
            
        }
    }
}
