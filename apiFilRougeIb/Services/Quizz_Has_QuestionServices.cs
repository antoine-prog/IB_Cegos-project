using apiFilRougeIb.Dto.Create;
using apiFilRougeIb.Models;
using System;
using System.Collections.Generic;

namespace apiFilRougeIb.Services
{
    internal class Quizz_Has_QuestionServices
    {
        private Repositories.Quizz_Has_QuestionRepository _quizzHasQuestionRepository;

        public Quizz_Has_QuestionServices()
        {
            this._quizzHasQuestionRepository = new Repositories.Quizz_Has_QuestionRepository(new Utils.QueryBuilder());
        }
        internal List<Quizz_Has_Question> Get()
        {
            return this._quizzHasQuestionRepository.FindAll();
        }
        internal int Delete(long id)
        {
            return this._quizzHasQuestionRepository.Delete(id);
        }

        internal List<Quizz_Has_Question> Post(CreateQuizzHasQuestionDto qhq)
        {
            Models.Quizz_Has_Question qhqModel = TransformDtoToModel(qhq);
            Models.Quizz_Has_Question qhqModelCreated = this._quizzHasQuestionRepository.Create(qhqModel);
            return TransformModelToAfterCreateDto(qhqModelCreated, true);
        }

        private List<Quizz_Has_Question> TransformModelToAfterCreateDto(object solutionModelCreated, bool v)
        {
            throw new NotImplementedException();
        }

        private Quizz_Has_Question TransformDtoToModel(CreateQuizzHasQuestionDto qhq)
        {
            throw new NotImplementedException();
        }
    }
}