using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using ProjetoEpicRPGAPI.Models;
using ProjetoEpicRPGAPI.Data;

namespace ProjetoEpicRPGAPI.Data

{
    public class Repository : IRepository
    {
        public DungeonContext Context { get; }

        public Repository(DungeonContext context)
        {
            this.Context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.Context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Como é tipo Task vai gerar thread, então vamos definir o método como assíncrono (async)
            // Por ser assíncrono, o return deve esperar (await) se tem alguma coisa para salvar no BD
            // Ainda verifica se fez alguma alteração no BD, se for maior que 0 retorna true ou false
            return (await this.Context.SaveChangesAsync() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            //throw new System.NotImplementedException();
            this.Context.Update(entity);
        }

        public async Task<Heroi[]> GetAllHeroisAsync()
        {
            //throw new System.NotImplementedException();
            //Retornar para uma query qualquer do tipo Aluno
            IQueryable<Heroi> consultaHerois = this.Context.Herois;
            consultaHerois = consultaHerois.OrderBy(a => a.IdHeroi);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaHerois.ToArrayAsync();
        }

        public async Task<Heroi> GetAllHeroisAsyncByRa(int IdHeroi)
        {
            //throw new System.NotImplementedException();
            //Retornar para uma query qualquer do tipo Aluno
            IQueryable<Heroi> consultaHerois = this.Context.Herois;
            consultaHerois = consultaHerois.OrderBy(a => a.IdHeroi).Where(Heroi => Heroi.IdHeroi == IdHeroi);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaHerois.FirstOrDefaultAsync();
        }
    }
}