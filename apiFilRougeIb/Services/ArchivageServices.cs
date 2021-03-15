using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Services
{
    public class ArchivageServices
    {

        private Repositories.ArchivageRepository _archivageRepository;

        public ArchivageServices()
        {
            this._archivageRepository = new Repositories.ArchivageRepository(new Utils.QueryBuilder());
        }

        /// <summary>
        ///  Permet de récupérer une liste de niveaux
        /// </summary>
        /// <returns>List<Models.todo></returns>
        public List<Dto.FindAll.FindAllArchivagesDto> GetArchivages()
        {
            List<Models.Archivage> archivage = this._archivageRepository.FindAll();
            List<Dto.FindAll.FindAllArchivagesDto> archivageDto = new List<Dto.FindAll.FindAllArchivagesDto>();
            archivage.ForEach(archivage =>
            {
                archivageDto.Add(TransformModelToDto(archivage));
            });
            return archivageDto;
        }

        /// <summary>
        ///     Retourne un niveau
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Models.Todo</returns>
        internal Dto.FindAll.FindAllArchivagesDto GetArchivages(long id)
        {
            Models.Archivage archivage = this._archivageRepository.Find(id);
            Dto.FindAll.FindAllArchivagesDto archivageDto = TransformModelToDto(archivage);
            return archivageDto;
        }

        /// <summary>
        ///     Persister un niveau
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateArchivageDto PostArchivages(Dto.Create.CreateArchivageDto archivage)
        {
            Models.Archivage archivageModel = TransformDtoToModel(archivage);
            Models.Archivage archivageModelCreated = this._archivageRepository.Create(archivageModel);
            return TransformModelToAfterCreateDto(archivageModelCreated, true);
        }

        /// <summary>
        ///     Mets à jours un niveau
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTodo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateArchivageDto PutArchivage(long id, Dto.Create.CreateArchivageDto newArchivage)
        {
            Models.Archivage archivageModel = TransformDtoToModel(newArchivage);
            Models.Archivage archivageModelUpdated = this._archivageRepository.Update(id, archivageModel);
            return TransformModelToAfterCreateDto(archivageModelUpdated, true);
        }
        /// <summary>
        ///     Supprime un niveau
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int Delete(long id)
        {
            return this._archivageRepository.Delete(id);
        }
        private Dto.FindAll.FindAllArchivagesDto TransformModelToDto(Models.Archivage archivage)
        {
            return new Dto.FindAll.FindAllArchivagesDto((DateTime)archivage.DateCompleted, archivage.IsValidated, archivage.Quizz_idQuizz, archivage.User_idUser, archivage.IdArchivage);
        }
        private Models.Archivage TransformDtoToModel(Dto.Create.CreateArchivageDto archivage)
        {
            return new Models.Archivage(/*archivage.DateCompleted,*/null, archivage.IsValidated, archivage.Quizz_idQuizz, archivage.User_idUser);
        }
        private Dto.AfterCreate.AfterCreateArchivageDto TransformModelToAfterCreateDto(Models.Archivage archivage, bool isCreated)
        {
            return new Dto.AfterCreate.AfterCreateArchivageDto((DateTime)archivage.DateCompleted, archivage.IsValidated, archivage.Quizz_idQuizz, archivage.User_idUser, archivage.IdArchivage);
        }


    }
}
