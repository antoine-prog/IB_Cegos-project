using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Services
{
    public class AnswerServices
    {

        private Repositories.AnswerRepository _answerRepository;

        public AnswerServices()
        {
            this._answerRepository = new Repositories.AnswerRepository(new Utils.QueryBuilder());
        }

        /// <summary>
        ///  Permet de récupérer une liste de niveaux
        /// </summary>
        /// <returns>List<Models.todo></returns>
        public List<Dto.FindAll.FindAllAnswersDto> GetAnswers()
        {
            List<Models.Answer> answer = this._answerRepository.FindAll();
            List<Dto.FindAll.FindAllAnswersDto> answerDto = new List<Dto.FindAll.FindAllAnswersDto>();
            answer.ForEach(answer =>
            {
                answerDto.Add(TransformModelToDto(answer));
            });
            return answerDto;
        }

        /// <summary>
        ///     Retourne un niveau
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Models.Todo</returns>
        internal Dto.FindAll.FindAllAnswersDto GetAnswer(long id)
        {
            Models.Answer answer = this._answerRepository.Find(id);
            Dto.FindAll.FindAllAnswersDto answerDto = TransformModelToDto(answer);
            return answerDto;
        }

        /// <summary>
        ///     Persister un niveau
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateAnswerDto PostAnswer(Dto.Create.CreateAnswerDto answer)
        {
            Models.Answer answerModel = TransformDtoToModel(answer);
            Models.Answer answerModelCreated = this._answerRepository.Create(answerModel);
            return TransformModelToAfterCreateDto(answerModelCreated, true);
        }

        /// <summary>
        ///     Mets à jours un niveau
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTodo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateAnswerDto PutAnswer(long id, Dto.Create.CreateAnswerDto newAnswer)
        {
            Models.Answer answerModel = TransformDtoToModel(newAnswer);
            Models.Answer answerModelUpdated = this._answerRepository.Update(id, answerModel);
            return TransformModelToAfterCreateDto(answerModelUpdated, true);
        }
        /// <summary>
        ///     Supprime un niveau
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int Delete(long id)
        {
            return this._answerRepository.Delete(id);
        }
        private Dto.FindAll.FindAllAnswersDto TransformModelToDto(Models.Answer answer)
        {
            return new Dto.FindAll.FindAllAnswersDto(answer.answer,answer.Result, answer.IdAnswer);
        }
        private Models.Answer TransformDtoToModel(Dto.Create.CreateAnswerDto answer)
        {
            return new Models.Answer(answer.Answer_, answer.Result );
        }
        private Dto.AfterCreate.AfterCreateAnswerDto TransformModelToAfterCreateDto(Models.Answer answer, bool isCreated)
        {
            return new Dto.AfterCreate.AfterCreateAnswerDto(answer.answer, isCreated, answer.Result, answer.IdAnswer);
        }


    }
}
