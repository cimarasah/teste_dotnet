using AMcom.Teste.Service.Interface.DTO;
using AMcom.Teste.Service.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AMcom.Teste.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ubs")]
    public class UbsController : ControllerBase
    {
        private readonly IUbsService service;

        public UbsController(IUbsService service)
        {
            this.service = service;
        }

        // GET api/listarUbs
        [HttpGet("listarUbs")]
        public ActionResult<IEnumerable<UbsDTO>> Get() =>
            Ok(service.GetUbs());

       
        // GET api/ubs/{id}
        [HttpGet("{id}")]
        public ActionResult<UbsDTO> Get(int id) =>
            Ok(service.GetUbsByID(id));

        // GET api/localizaUbs/{latitude}/{longitude}
        [HttpGet("localizaUbs/{latitude}/{longitude}")]
        public ActionResult<IEnumerable<UbsDTO>> GetlocalizaUbs(double latitude, double longitude) =>
            Ok(service.GetByLocationAsync(latitude, longitude, 5));

        // POST api/ubs
        [HttpPost]
        public IActionResult Post(UbsDTO ubs)
        {
            service.Add(ubs);
            return Ok();
        }

        // POST api/rangeUbs
        [HttpPost("postRange/{listUbs}")]
        public IActionResult PostRange(List<UbsDTO> listUbs)
        {
            service.AddRange(listUbs);
            return Ok();
        }
        // POST api/ImportUbs/{path}
        [HttpPost("importUbs/{path}")]
        public IActionResult ImportUbs(string path)
        {
            service.ImportCsvUbs(path);
            return Ok();
        }
        // DELETE api/ubs/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
            Ok();
        }
    }
}
