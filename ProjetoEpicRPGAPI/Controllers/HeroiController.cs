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
    public class HeroiController : Controller
    {
        public IRepository Repo{get;}
        public HeroiController(IRepository repo)
        {
            this.Repo = repo;
        }

        //Funcionando
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repo.GetAllHeroisAsync();
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
       }
        
        //Funcionando
        [HttpGet("{idHeroi}")]
        public async Task<IActionResult> Get(int idHeroi)
        {
            try
            {
                var result = await this.Repo.GetHeroisAsyncById(idHeroi);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
        
        //Funcionando

        [HttpPost]
        public async Task<IActionResult> post(Heroi exemplar)
        {
            try
            {
                this.Repo.Add(exemplar);

                if(await this.Repo.SaveChangesAsync())
                {
                    Console.WriteLine("Insercao concluida de heroi");
                    
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

        [HttpPut("{idHeroi}")]
        public async Task<IActionResult> put(int idHeroi, Heroi exemplar)
        {
            try
            {
                this.Repo.Update(exemplar);
                if(await this.Repo.SaveChangesAsync())
                {
                    Console.WriteLine("As alteracoes em heroi foram salvas");

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
        [HttpDelete("{idHeroi}")]
        public async Task<IActionResult> delete(int idHeroi)
        {
            try
            {
                var heroi = this.Repo.GetHeroisAsyncById(idHeroi);
                Console.WriteLine("Verificando existencia de heroi");

                if(heroi == null)
                {
                    Console.WriteLine("Nao foi possivel achar o heroi");
                    return NotFound();
                }
                else
                {                     
                    Console.WriteLine("Deletando heroi....");
                    this.Repo.Delete(heroi);
                }

                Console.WriteLine("Salvando alteracoes");
                if (await this.Repo.SaveChangesAsync())
                {
                    Console.WriteLine("Alteracoes salvas");
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
        [HttpGet("u/{codUsuario}")]
        public async Task<IActionResult> GetHeroisU(int codUsuario)
        {
            var result = await this.Repo.GetHeroisDoUsuario(codUsuario);
            return Ok(result);
        }
    }
}

/*

Get:    Pegar todos / unico item de uma tabela
Post:   inserir todos / unico item para uma tabela
Put:    Editar todos / unico dado da tabela 
Delete: Deletar

*/