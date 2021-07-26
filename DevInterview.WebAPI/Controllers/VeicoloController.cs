using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("veicoli")]
    public class VeicoloController : Controller
    {
        private IRepository<Veicolo, int> service;
        public VeicoloController(IRepository<Veicolo, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getVeicoli()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getVeicoloById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createVeicolo([FromBody] Veicolo veicolo)
        {
            return Ok(service.Save(veicolo));
        }
        [HttpPatch("{id}")]
        public IActionResult createVeicolo(int id, [FromBody] Veicolo veicolo)
        {
            return Ok(service.Save(veicolo));
        }
    }
}
