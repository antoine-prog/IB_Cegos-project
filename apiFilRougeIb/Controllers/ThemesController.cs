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
    public class ThemesController : ControllerBase
    {

        Services.ThemeServices themeServices;

        public ThemesController()
        {
            this.themeServices = new Services.ThemeServices();
        }

        // GET: api/<TodosController>
        [HttpGet]
        public List<Dto.FindAll.FindAllThemesDto> Get()
        {
            return themeServices.GetThemes();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public Dto.FindAll.FindAllThemesDto Get(long id)
        {
            return themeServices.GetTheme(id);
        }

        // POST api/<TodosController>
        [HttpPost]
        public Dto.AfterCreate.AfterCreateThemeDto Post([FromBody] Dto.Create.CreateThemeDto theme)
        {
            return themeServices.PostTheme(theme);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public Dto.AfterCreate.AfterCreateThemeDto Put(long id, [FromBody] Dto.Create.CreateThemeDto theme)
        {
            return themeServices.PutTheme(id, theme);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            return themeServices.Delete(id);
        }





    }
}
