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

        [HttpGet("{id}/{join}")]
        public Dto.FindAll.FindAllUsersDto Get(long id, string join = null)
        {
            return userServices.GetUser(id, join);

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
            return userServices.Delete(id);
        }




    }
}

