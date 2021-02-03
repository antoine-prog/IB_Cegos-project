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
    }
}