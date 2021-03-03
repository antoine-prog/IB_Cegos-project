using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace apiFilRougeIb.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        Services.UserServices userServices;

        public UsersController()
        {
            this.userServices = new Services.UserServices();
        }

        // GET: api/<TodosController>
        [HttpGet]
        public List<Dto.FindAll.FindAllUsersDto> Get()
        {
            return userServices.GetUsers();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public Dto.FindAll.FindAllUsersDto Get(long id)
        {
            return userServices.GetUser(id);
        }

        [HttpGet("check/{mail}")]
        public long? Check(string mail)
        {
            return userServices.Check(mail);
        }

        [HttpGet("{id}/useranswers")]
        public Dto.FindAll.FindAllUsersDto Get2(long id)
        {
            return userServices.GetUserJoinUserAnwsers(id);

        }
        //[HttpGet("{id}/level")]
        //public Dto.FindAll.FindAllUsersDto Get3(long id)
        //{
        //    return userServices.GetUserJoinLevel(id);            
        //}
        [HttpGet("{id}/quizz")]
        public Dto.FindAll.FindAllUsersDto Get4(long id)
        {
            return userServices.GetUserJoinQuizz(id);
        }

        // POST api/<TodosController>
        [HttpPost]
        public Dto.AfterCreate.AfterCreateUserDto Post([FromBody] Dto.Create.CreateUserDto user)
        {
            return userServices.PostUser(user);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public Dto.AfterCreate.AfterCreateUserDto Put(long id, [FromBody] Dto.Create.CreateUserDto user)
        {
            return userServices.PutUser(id, user);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            Console.WriteLine("je suis dans le back");
            return userServices.Delete(id);
        }
    }
}

