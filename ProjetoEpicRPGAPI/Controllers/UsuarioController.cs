using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using ProjetoEpicRPGAPI.Models;
using ProjetoEpicRPGAPI.Data;

namespace ProjetoEpicRPGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController()]
    public class UsuarioController : Controller
    {
        public IRepository Repo{get;}

        public UsuarioController(IRepository repo)
        {
            this.Repo = repo;
        }

        //Adaptar TUDO

        //testar
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            var result = await this.Repo.GetAllUsuarios();
            return Ok(result);
        }

        //testar
        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> Get(int idUsuario)
        {
            var result = await this.Repo.GetUsuarioById(idUsuario);
            return Ok(result);
        }

        //testar
        [HttpGet("h/{idUsuario}")]
        public async Task<IActionResult> GetHerois(int idUsuario)
        {
            var result = await this.Repo.GetHeroisDoUsuario(idUsuario);
            return Ok(result);
        }

        //testar
        [HttpGet("{usuario}/{senha}")]
        public async Task<IActionResult> Get(string usuario, string senha)
        {
            var result = await this.Repo.GetCodigoUsuario(usuario, senha);
            
            result[0].email = "";
            result[0].senha = "";

            return Ok(result);
        }
    }
}