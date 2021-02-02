using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Services
{
    public class UserAnswerServices
    {

        private Repositories.UserAnswerRepository _userAnswerRepository;

        public UserAnswerServices()
        {
            this._userAnswerRepository = new Repositories.UserAnswerRepository(new Utils.QueryBuilder());
        }

        /// <summary>
        ///  Permet de récupérer une liste de userAnswers
        /// </summary>
        /// <returns>List<Models.todo></returns>
        public List<Models.UserAnswer> GetUsers()
        {
            return this._userAnswerRepository.FindAll();
        }

        /// <summary>
        ///  Permet de récupérer une liste de userAnswers
        /// </summary>
        /// <returns>List<Models.todo></returns>
        //public List<Models.UserAnswer> GetUsers(long iduser)
        //{
        //    return this._userAnswerRepository.FindUsers(iduser);
        //}


        /// <summary>
        ///     Retourne un userAnswer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Models.Todo</returns>
        //internal Dto.FindAll.FindAllUserAnswersDto GetUserAnswer(long id)
        //{
        //    Models.UserAnswer userAnswer = this._userAnswerRepository.Find(id);
        //    Dto.FindAll.FindAllUserAnswersDto userAnswerDto = TransformModelToDto(userAnswer);
        //    return userAnswerDto;
        //}

        /// <summary>
        ///     Persister un userAnswer
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        //internal Dto.AfterCreate.AfterCreateUserAnswerDto PostUserAnswer(Dto.Create.CreateUserAnswerDto userAnswer)
        //{
        //    Models.UserAnswer userAnswerModel = TransformDtoToModel(userAnswer);
        //    Models.UserAnswer userAnswerModelCreated = this._userAnswerRepository.Create(userAnswerModel);
        //    return TransformModelToAfterCreateDto(userAnswerModelCreated, true);
        //}

        /// <summary>
        ///     Mets à jours un userAnswer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTodo"></param>
        /// <returns></returns>
        //internal Dto.AfterCreate.AfterCreateUserAnswerDto PutUserAnswer(long id, Dto.Create.CreateUserAnswerDto newUserAnswer)
        //{
        //    Models.UserAnswer userAnswerModel = TransformDtoToModel(newUserAnswer);
        //    Models.UserAnswer userAnswerModelUpdated = this._userAnswerRepository.Update(id, userAnswerModel);
        //    return TransformModelToAfterCreateDto(userAnswerModelUpdated, true);
        //}
        /// <summary>
        ///     Supprime un userAnswer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int Delete(long id)
        {
            return this._userAnswerRepository.Delete(id);
        }
        //private Dto.FindAll.FindAllUserAnswersDto TransformModelToDto(Models.UserAnswer userAnswer)
        //{
        //    return new Dto.FindAll.FindAllUserAnswersDto(userAnswer.Category, userAnswer.IdUserAnswer);
        //}
        //private Models.UserAnswer TransformDtoToModel(Dto.Create.CreateUserAnswerDto userAnswer)
        //{
        //    return new Models.UserAnswer(userAnswer.Category);
        //}
        //private Dto.AfterCreate.AfterCreateUserAnswerDto TransformModelToAfterCreateDto(Models.UserAnswer userAnswer, bool isCreated)
        //{
        //    return new Dto.AfterCreate.AfterCreateUserAnswerDto(userAnswer.Category, isCreated, userAnswer.IdUserAnswer);
        //}


    }
}
