using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Services
{
    public class LevelServices
    {

        private Repositories.LevelRepository _levelRepository;

        public LevelServices()
        {
            this._levelRepository = new Repositories.LevelRepository(new Utils.QueryBuilder());
        }

        /// <summary>
        ///  Permet de récupérer une liste de niveaux
        /// </summary>
        /// <returns>List<Models.todo></returns>
        public List<Dto.FindAll.FindAllLevelDto> GetLevel()
        {
            List<Models.Level> level = this._levelRepository.FindAll();
            List<Dto.FindAll.FindAllLevelDto> levelDto = new List<Dto.FindAll.FindAllLevelDto>();
            level.ForEach(level =>
            {
                levelDto.Add(TransformModelToDto(level));
            });
            return levelDto;
        }

        /// <summary>
        ///     Retourne un niveau
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Models.Todo</returns>
        internal Dto.FindAll.FindAllLevelDto GetLevel(long id)
        {
            Models.Level level = this._levelRepository.Find(id);
            Dto.FindAll.FindAllLevelDto levelDto = TransformModelToDto(level);
            return levelDto;
        }

        /// <summary>
        ///     Persister un niveau
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateLevelDto PostLevel(Dto.Create.CreateLevelDto level)
        {
            Models.Level levelModel = TransformDtoToModel(level);
            Models.Level levelModelCreated = this._levelRepository.Create(levelModel);
            return TransformModelToAfterCreateDto(levelModelCreated, true);
        }

        /// <summary>
        ///     Mets à jours un niveau
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTodo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateLevelDto PutLevel(long id, Dto.Create.CreateLevelDto newLevel)
        {
            Models.Level levelModel = TransformDtoToModel(newLevel);
            Models.Level levelModelUpdated = this._levelRepository.Update(id, levelModel);
            return TransformModelToAfterCreateDto(levelModelUpdated, true);
        }
        /// <summary>
        ///     Supprime un niveau
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int Delete(long id)
        {
            return this._levelRepository.Delete(id);
        }
        private Dto.FindAll.FindAllLevelDto TransformModelToDto(Models.Level level)
        {
            return new Dto.FindAll.FindAllLevelDto(level.Title, level.IdLevel);
        }
        private Models.Level TransformDtoToModel(Dto.Create.CreateLevelDto level)
        {
            return new Models.Level(level.Title);
        }
        private Dto.AfterCreate.AfterCreateLevelDto TransformModelToAfterCreateDto(Models.Level level, bool isCreated)
        {
            return new Dto.AfterCreate.AfterCreateLevelDto(level.Title, isCreated, level.IdLevel);
        }


    }
}
