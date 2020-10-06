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
            var result = this.Repo.GetAllHeroisAsync();
            return Ok(result);
        }
        
        [HttpGet("{idHeroi}")]
        public IActionResult Get(int idHeroi)
        {
            var result = this.Repo.GetAllHeroisAsyncById(idHeroi);
            return Ok(result);
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

/*

Get:    Pegar todos / unico item de uma tabela
Post:   inserir todos / unico item para uma tabela
Put:    Editar todos / unico dado da tabela 
Delete: Deletar

*/