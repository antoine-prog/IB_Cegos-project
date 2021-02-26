using apiFilRougeIb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuizzJoinQuestionDto : FindAllQuizzDto
    {
        public List<Models.Question> questions { get; set; }
        public FindAllQuizzJoinQuestionDto(FindAllQuizzDto quizz) : base(quizz.Name, quizz.User_idUser, quizz.Theme_idTheme,quizz.Code, quizz.DateClosed,
            quizz.Level_idLevel, quizz.Timer,quizz.IdQuizz)
        {
            this.questions = new QuestionRepository(new Utils.QueryBuilder()).FindAllByQuizz((long)quizz.IdQuizz);
        }
    }
}
