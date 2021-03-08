using apiFilRougeIb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

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
            return userServices.Delete(id);
        }

        // POST api/<TodosController>
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Authenticate model)
        {
            Console.WriteLine("je suis dans le back");
            Console.WriteLine(model);
            var user = this.userServices.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                Console.WriteLine("l'user n'existe pas");
                return BadRequest(new { message = "Username or password is incorrect" });
            }
               

            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.IdUser.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.IdUser,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }


    }
}

