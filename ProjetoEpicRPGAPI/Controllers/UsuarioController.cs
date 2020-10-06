using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Get()
        {
            var result = this.Repo.GetAllUsuarios();
            return Ok(result);
        }
        
        [HttpGet("{idUsuario}")]
        public IActionResult Get(int idUsuario)
        {
            var result = this.Repo.GetAllHeroisAsyncById(idUsuario);
            return Ok(result);
        }

        [HttpGet("{usuario}/{senha}")]
        public IActionResult Get(string usuario, string senha)
        {
            var result = this.Repo.GetCodigoUsuario(usuario, senha);
            return Ok(result);
        }
    }
}