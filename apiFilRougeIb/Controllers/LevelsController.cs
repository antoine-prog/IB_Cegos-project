using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {

        Services.LevelServices levelServices;

        public LevelController()
        {
            this.levelServices = new Services.LevelServices();
        }

        // GET: api/<TodosController>
        [HttpGet]
        public List<Dto.FindAll.FindAllLevelDto> Get()
        {
            return levelServices.GetLevel();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public Dto.FindAll.FindAllLevelDto Get(long id)
        {
            return levelServices.GetLevel(id);
        }

        // POST api/<TodosController>
        [HttpPost]
        public Dto.AfterCreate.AfterCreateLevelDto Post([FromBody] Dto.Create.CreateLevelDto level)
        {
            return levelServices.PostLevel(level);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public Dto.AfterCreate.AfterCreateLevelDto Put(long id, [FromBody] Dto.Create.CreateLevelDto level)
        {
            return levelServices.PutLevel(id, level);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            return levelServices.Delete(id);
        }





    }
}
