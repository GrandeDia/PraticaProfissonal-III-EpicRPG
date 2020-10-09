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

        //Funcionando
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            var result = await this.Repo.GetAllUsuarios();
            return Ok(result);
        }

        //Funcionando
        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> Get(int idUsuario)
        {
            var result = await this.Repo.GetUsuarioById(idUsuario);
            return Ok(result);
        }

        //Funcionando
        [HttpGet("h/{idUsuario}")]
        public async Task<IActionResult> GetHerois(int idUsuario)
        {
            var result = await this.Repo.GetHeroisDoUsuario(idUsuario);
            return Ok(result);
        }

        //Funcionando
        [HttpGet("{usuario}/{senha}")]
        public async Task<IActionResult> Get(string usuario, string senha)
        {
            var result = await this.Repo.GetCodigoUsuario(usuario, senha);
            
            result[0].email = "";
            result[0].senha = "";

            return Ok(result);
        }

        //Funcionando
        [HttpPost]
        public async Task<IActionResult> post(Usuario exemplar)
        {
            try
            {
                this.Repo.Add(exemplar);

                if(await this.Repo.SaveChangesAsync())
                {
                    Console.WriteLine("Insercao de usuario concluida");
                    
                    //ver depois
                    //return Created($"/api/Heroi/{exemplar.IdHeroi}", exemplar);

                    return Ok();
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            
            return BadRequest();
        }
        
        //Funcionando
        [HttpPut("{idUsuario}")]
        public async Task<IActionResult> put(int idUsuario, Usuario exemplar)
        {
            try
            {
                this.Repo.Update(exemplar);
                if(await this.Repo.SaveChangesAsync())
                {
                    Console.WriteLine("As alteracoes em usuario foram salvas");

                    return Ok();
                    //return Created($"/api/Heroi/{exemplar.IdHeroi}" , heroi );
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            
            return BadRequest();
        }

        //Funcionando
        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> delete(int idUsuario)
        {
            try
            {

                var usuario = await this.Repo.GetUsuarioById(idUsuario);
                
                Console.WriteLine("Verificando existencia do usuario");

                if(usuario == null)
                {
                    Console.WriteLine("Não foi possivel achar o usuario");
                    return NotFound();
                }
                else
                {
                    Console.WriteLine("Usuario encontrado");

                    var herois = await this.Repo.GetHeroisDoUsuario(idUsuario);

                    Console.WriteLine("verificando existencia de herois");

                    if(herois.Length == 0)
                    {
                        Console.WriteLine("O usuario não possui herois");
                    }
                    else
                    {
                        Console.WriteLine("Deletando os herois");
                        
                        foreach(Heroi heroi in herois)
                        {
                            this.Repo.Delete(heroi);
                            if(await this.Repo.SaveChangesAsync())
                            {
                                Console.WriteLine("Heroi deletado com sucesso");
                            }
                        }
                    }

                    Console.WriteLine("Deletando Usuario");
                    this.Repo.Delete(usuario);

                    Console.WriteLine("Salvando alteracoes");
                    if (await this.Repo.SaveChangesAsync())
                    {
                        Console.WriteLine("Alteracoes salvas");
                        return Ok();
                    }
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }
    }
}