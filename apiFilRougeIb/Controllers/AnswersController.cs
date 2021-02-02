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
    public class AnswersController : ControllerBase
    {

        Services.AnswerServices answerServices;

        public AnswersController()
        {
            this.answerServices = new Services.AnswerServices();
        }

        // GET: api/<TodosController>
        [HttpGet]
        public List<Dto.FindAll.FindAllAnswersDto> Get()
        {
            return answerServices.GetAnswers();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public Dto.FindAll.FindAllAnswersDto Get(long id)
        {
            return answerServices.GetAnswer(id);
        }

        // POST api/<TodosController>
        [HttpPost]
        public Dto.AfterCreate.AfterCreateAnswerDto Post([FromBody] Dto.Create.CreateAnswerDto answer)
        {
            return answerServices.PostAnswer(answer);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public Dto.AfterCreate.AfterCreateAnswerDto Put(long id, [FromBody] Dto.Create.CreateAnswerDto answer)
        {
            return answerServices.PutAnswer(id, answer);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            return answerServices.Delete(id);
        }


    }
}
