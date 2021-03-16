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
    public class Quizz_Has_QuestionsController : ControllerBase
    {
        Services.Quizz_Has_QuestionServices quizz_has_questionServices;

        public Quizz_Has_QuestionsController()
        {
            this.quizz_has_questionServices = new Services.Quizz_Has_QuestionServices();
        }


        // POST api/<UserAnswersController>
        [HttpGet]
        public List<Models.Quizz_Has_Question> Get()
        {
            return quizz_has_questionServices.Get();
        }

        [HttpPost]
        public Models.Quizz_Has_Question Post([FromBody] Models.Quizz_Has_Question qhq)
        {
            return quizz_has_questionServices.Post(qhq);
        }
    }
}
