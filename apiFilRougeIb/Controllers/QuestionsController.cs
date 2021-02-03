using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        Services.QuestionServices questionServices;

        public QuestionsController()
        {
            this.questionServices = new Services.QuestionServices();
        }

        // GET: api/<TodosController>
        [HttpGet]
        public List<Dto.FindAll.FindAllQuestionsDto> Get()
        {
            return questionServices.GetQuestions();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public Dto.FindAll.FindAllQuestionsDto Get(long id)
        {
            return questionServices.GetQuestion(id);
        }
        [HttpGet("{id}/solution")]
        public Dto.FindAll.FindAllQuestionsDto Get2(long id)
        {
            return questionServices.GetQuestionJoinSolution(id);
        }
        

        // POST api/<TodosController>
        [HttpPost]
        public Dto.AfterCreate.AfterCreateQuestionDto Post([FromBody] Dto.Create.CreateQuestionDto question)
        {
            return questionServices.PostQuestion(question);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public Dto.AfterCreate.AfterCreateQuestionDto Put(long id, [FromBody] Dto.Create.CreateQuestionDto question)
        {
            return questionServices.PutQuestion(id, question);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            return questionServices.Delete(id);
        }
    }
}
