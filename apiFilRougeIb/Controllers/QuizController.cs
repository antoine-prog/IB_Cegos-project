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
    public class QuizController : ControllerBase
    {

        Services.QuizzServices quizzServices;

        public QuizController()
        {
            this.quizzServices = new Services.QuizzServices();
        }

        // GET: api/<TodosController>
        [HttpGet]
        public List<Dto.FindAll.FindAllQuizzDto> Get()
        {
            return quizzServices.GetQuizz();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public Dto.FindAll.FindAllQuizzDto Get(long id)
        {
            return quizzServices.GetQuizz(id);
        }

        // POST api/<TodosController>
        [HttpPost]
        public Dto.AfterCreate.AfterCreateQuizzDto Post([FromBody] Dto.Create.CreateQuizzDto quiz)
        {
            return quizzServices.PostQuizz(quiz);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public Dto.AfterCreate.AfterCreateQuizzDto Put(long id, [FromBody] Dto.Create.CreateQuizzDto quiz)
        {
            return quizzServices.PutQuizz(id, quiz);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            return quizzServices.Delete(id);
        }


    }
}
