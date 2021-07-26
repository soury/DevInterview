using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("tipi_veicolo")]
    public class TipoVeicoloController : Controller
    {
        private IRepository<TipoVeicolo, string> service;
        public TipoVeicoloController(IRepository<TipoVeicolo, string> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getById(string id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult create([FromBody] TipoVeicolo data)
        {
            return Ok(service.Save(data));
        }
        [HttpPatch("{id}")]
        public IActionResult update(int id, [FromBody] TipoVeicolo data)
        {
            return Ok(service.Save(data));
        }
    }
}
