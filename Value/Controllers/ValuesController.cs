using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMcom.Teste.Service.Interface.DTO;
using AMcom.Teste.Service.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace Value.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUbsService service;

        public ValuesController(IUbsService service)
        {
            this.service = service;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<UbsDTO>> Get()
        {
            return Ok(service.GetUbs());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
