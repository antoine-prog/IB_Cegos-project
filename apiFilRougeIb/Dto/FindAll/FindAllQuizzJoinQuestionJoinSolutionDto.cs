using apiFilRougeIb.Models;
using apiFilRougeIb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuizzJoinQuestionJoinSolutionDto : FindAllQuizzDto
    {
        public List<FindAllQuestionJoinSolutionDto> listquestionsolution { get; set; }

        public FindAllQuizzJoinQuestionJoinSolutionDto(FindAllQuizzDto quizz) : base(quizz.Name, quizz.User_idUser, quizz.Theme_idTheme, quizz.Code, quizz.DateClosed,
            quizz.Level_idLevel, quizz.Timer, quizz.IdQuizz)
        {
            List<Question> questions = new QuestionRepository(new Utils.QueryBuilder()).FindAllByQuizz((long)quizz.IdQuizz);

            listquestionsolution = new List<FindAllQuestionJoinSolutionDto>();
            foreach(Question question in questions)
            {

                listquestionsolution.Add(new FindAllQuestionJoinSolutionDto(question));
            }
            
        }
    }
}
