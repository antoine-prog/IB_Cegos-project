//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using apiFilRougeIb.Models;
//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace apiFilRougeIb.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

    
//    public class UserAnswersController : ControllerBase
//    {
//        // GET api/<UserAnswersController>/5
//        //[HttpGet("{id}/Answer}")]
//        //public string Get(long idanswer)
//        //{
//        //    return "value";
//        //}
//        Services.UserAnswerServices userAnswerServices;

//        public UserAnswersController()
//        {
//            this.userAnswerServices = new Services.UserAnswerServices();
//        }
//        [HttpGet("{id}/Questions}")]
//        public List<(long,long)> Get(long idQuestion)
//        {
//            List<(long,long)> listUserAnswers = userAnswerServices.GetUserAnswers(idQuestion);
//            return listUserAnswers;
//        }

//        // POST api/<UserAnswersController>
//        [HttpPost]
//        public void Post([FromBody] long iduser, long answer_idanswer,long question_idquestion)
//        {

//        }

        
//    }
//}
