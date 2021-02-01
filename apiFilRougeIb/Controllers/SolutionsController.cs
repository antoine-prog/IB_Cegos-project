using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiFilRougeIb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SolutionsController : ControllerBase
    {

        Services.SolutionServices SolutionServices;

        public SolutionsController()
        {
            this.SolutionServices = new Services.SolutionServices();
        }
        // GET: api/<SolutionsController>
        [HttpGet]
        public List<Dto.FindAll.FindAllSolutionsDto> Get()
        {
            return SolutionServices.GetSolutions();
        }

        // GET api/<SolutionsController>/5
        [HttpGet("{id}")]
        public Dto.FindAll.FindAllSolutionsDto Get(long id)
        {
            return SolutionServices.GetSolution(id);
        }

        // POST api/<SolutionsController>
        [HttpPost]
        public Dto.AfterCreate.AfterCreateSolutionDto Post([FromBody] Dto.Create.CreateSolutionDto theme)
        {
            return SolutionServices.PostSolution(theme);
        }

        // PUT api/<SolutionsController>/5
        [HttpPut("{id}")]
        public Dto.AfterCreate.AfterCreateSolutionDto Put(long id, [FromBody] Dto.Create.CreateSolutionDto Solution)
        {
            return SolutionServices.PutSolution(id, Solution);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            return SolutionServices.Delete(id);
        }



    }
}
