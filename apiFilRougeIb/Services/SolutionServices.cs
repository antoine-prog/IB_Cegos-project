using apiFilRougeIb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Services
{
    public class SolutionServices
    {

        private Repositories.SolutionRepository _solutionRepository;

        public SolutionServices()
        {
            this._solutionRepository = new Repositories.SolutionRepository(new Utils.QueryBuilder());
        }

        /// <summary>
        ///  Permet de récupérer une liste de solutions
        /// </summary>
        /// <returns>List<Models.todo></returns>
        public List<Dto.FindAll.FindAllSolutionsDto> GetSolutions()
        {
            List<Models.Solution> solutions = this._solutionRepository.FindAll();
            List<Dto.FindAll.FindAllSolutionsDto> solutionsDto = new List<Dto.FindAll.FindAllSolutionsDto>();
            solutions.ForEach(solution =>
            {
                solutionsDto.Add(TransformModelToDto(solution));
            });
            return solutionsDto;
        }

        /// <summary>
        ///     Retourne un solution
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Models.Todo</returns>
        internal Dto.FindAll.FindAllSolutionsDto GetSolution(long id)
        {
            Solution solution = this._solutionRepository.Find(id);
            Dto.FindAll.FindAllSolutionsDto solutionDto = TransformModelToDto(solution);
            return solutionDto;
        }

        /// <summary>
        ///     Persister un solution
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateSolutionDto PostSolution(Dto.Create.CreateSolutionDto solution)
        {
            Models.Solution solutionModel = TransformDtoToModel(solution);
            Models.Solution solutionModelCreated = this._solutionRepository.Create(solutionModel);
            return TransformModelToAfterCreateDto(solutionModelCreated, true);
        }

        /// <summary>
        ///     Mets à jours un solution
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTodo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateSolutionDto PutSolution(long id, Dto.Create.CreateSolutionDto newSolution)
        {
            Models.Solution solutionModel = TransformDtoToModel(newSolution);
            Models.Solution solutionModelUpdated = this._solutionRepository.Update(id, solutionModel);
            return TransformModelToAfterCreateDto(solutionModelUpdated, true);
        }
        /// <summary>
        ///     Supprime un solution
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int Delete(long id)
        {
            return this._solutionRepository.Delete(id);
        }
        private Dto.FindAll.FindAllSolutionsDto TransformModelToDto(Models.Solution solution)
        {
            return new Dto.FindAll.FindAllSolutionsDto(solution.solution, solution.Question_idQuestion ,solution.IdSolution);
        }
        private Models.Solution TransformDtoToModel(Dto.Create.CreateSolutionDto solution)
        {
            return new Models.Solution(solution.Solution,solution.Question_idQuestion);
        }
        private Dto.AfterCreate.AfterCreateSolutionDto TransformModelToAfterCreateDto(Models.Solution solution, bool isCreated)
        {
            return new Dto.AfterCreate.AfterCreateSolutionDto(solution.solution, solution.Question_idQuestion, isCreated, solution.IdSolution);
        }
    }
}
