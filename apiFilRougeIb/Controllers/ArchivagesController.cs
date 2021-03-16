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
    public class ArchivagesController : ControllerBase
    {

        Services.ArchivageServices archivageServices;

        public ArchivagesController()
        {
            this.archivageServices = new Services.ArchivageServices();
        }

        // GET: api/<TodosController>
        [HttpGet]
        public List<Dto.FindAll.FindAllArchivagesDto> Get()
        {
            return archivageServices.GetArchivages();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public Dto.FindAll.FindAllArchivagesDto Get(long id)
        {
            return archivageServices.GetArchivages(id);
        }
        [HttpGet("ArchivagesCreator/{idCreator}")]
        public List<Dto.FindAll.FindAllArchivagesDto> Get2(long idCreator)
        {
            return archivageServices.GetArchivagesByIdCreator(idCreator);
        }

        // POST api/<TodosController>
        [HttpPost]
        public Dto.AfterCreate.AfterCreateArchivageDto Post([FromBody] Dto.Create.CreateArchivageDto archivage)
        {
            return archivageServices.PostArchivages(archivage);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public Dto.AfterCreate.AfterCreateArchivageDto Put(long id, [FromBody] Dto.Create.CreateArchivageDto archivage)
        {
            return archivageServices.PutArchivage(id, archivage);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            return archivageServices.Delete(id);
        }





    }
}
