using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using ProjetoEpicRPGAPI.Models;
using ProjetoEpicRPGAPI.Data;

namespace ProjetoEpicRPGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController()]
    public class HeroiController : Controller
    {
        public IRepository Repo{get;}
        public HeroiController(IRepository repo)
        {
            this.Repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        
        [HttpGet("{idHeroi}")]
        public IActionResult Get(int idHeroi)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }

        [HttpPut("{idHeroi}")]

        public IActionResult put(int idHeroi)
        {
            return Ok();
        }
        
        [HttpDelete("{idHeroi}")]
        public IActionResult delete(int idHeroi)
        {
            return Ok();
        }
    }
}