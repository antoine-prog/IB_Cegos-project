using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Services
{
    public class QuestionServices
    {
        private Repositories.QuestionRepository _questionRepository;

        public QuestionServices()
        {
            this._questionRepository = new Repositories.QuestionRepository(new Utils.QueryBuilder());
        }

        /// <summary>
        ///  Permet de récupérer une liste de questions
        /// </summary>
        /// <returns>List<Models.todo></returns>
        public List<Dto.FindAll.FindAllQuestionsDto> GetQuestions()
        {
            List<Models.Question> questions = this._questionRepository.FindAll();
            List<Dto.FindAll.FindAllQuestionsDto> questionsDto = new List<Dto.FindAll.FindAllQuestionsDto>();
            questions.ForEach(question =>
            {
                questionsDto.Add(TransformModelToDto(question));
            });
            return questionsDto;
        }


        /// <summary>
        ///     Retourne une question
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Models.Todo</returns>
        internal Dto.FindAll.FindAllQuestionsDto GetQuestion(long id)
        {
            Models.Question question = this._questionRepository.Find(id);
            Dto.FindAll.FindAllQuestionsDto questionDto = TransformModelToDto(question);
            return questionDto;
        }

        internal Dto.FindAll.FindAllQuestionsDto GetQuestionJoinSolution(long id)
        {
            Models.Question question = this._questionRepository.Find(id);
            Dto.FindAll.FindAllQuestionsDto questionDto = TransformModelToDto(question);
            Dto.FindAll.FindAllQuestionsDto questionjoinsolutiondto = new Dto.FindAll.FindAllQuestionJoinSolutionDto(question);
            return questionjoinsolutiondto;
        }


        /// <summary>
        ///     Persister une question
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateQuestionDto PostQuestion(Dto.Create.CreateQuestionDto question)
        {
            Models.Question questionModel = TransformDtoToModel(question);
            Models.Question questionModelCreated = this._questionRepository.Create(questionModel);
            return TransformModelToAfterCreateDto(questionModelCreated, true);
        }

        /// <summary>
        ///     Mets à jours une question
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTodo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateQuestionDto PutQuestion(long id, Dto.Create.CreateQuestionDto newQuestion)
        {
            Models.Question questionModel = TransformDtoToModel(newQuestion);
            Models.Question questionModelUpdated = this._questionRepository.Update(id, questionModel);
            return TransformModelToAfterCreateDto(questionModelUpdated, true);
        }
        /// <summary>
        ///     Supprime une question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int Delete(long id)
        {
            return this._questionRepository.Delete(id);
        }
        private Dto.FindAll.FindAllQuestionsDto TransformModelToDto(Models.Question question)
        {
            return new Dto.FindAll.FindAllQuestionsDto(question.Title, question.Level_idLevel, question.IdQuestion);
        }
        private Models.Question TransformDtoToModel(Dto.Create.CreateQuestionDto question)
        {
            return new Models.Question(question.Title,  question.Level_idLevel);
        }
        private Dto.AfterCreate.AfterCreateQuestionDto TransformModelToAfterCreateDto(Models.Question question, bool isCreated)
        {
            return new Dto.AfterCreate.AfterCreateQuestionDto(question.Title,  question.Level_idLevel,isCreated, question.IdQuestion);
        }

    }
}
