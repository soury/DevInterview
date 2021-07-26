using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("usi")]
    public class UsoController : Controller
    {
        private IRepository<Uso, int> service;
        public UsoController(IRepository<Uso, int> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult create([FromBody] Uso data)
        {
            return Ok(service.Save(data));
        }
        [HttpPatch("{id}")]
        public IActionResult update(int id, [FromBody] Uso data)
        {
            return Ok(service.Save(data));
        }
    }
}
