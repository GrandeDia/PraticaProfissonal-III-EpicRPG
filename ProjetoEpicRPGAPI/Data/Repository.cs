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
            //Retornar para uma query qualquer do tipo Heroi
            IQueryable<Heroi> consultaHerois = this.Context.Herois;
            consultaHerois = consultaHerois.OrderBy(h => h.IdHeroi);
            return consultaHerois.ToArray();
            
            // aqui efetivamente ocorre o SELECT no BD
            //return await consultaHerois.ToArrayAsync();
        }

        public Heroi[] GetAllHeroisAsyncById(int IdHeroi)
        {
            //throw new System.NotImplementedException();
            //Retornar para uma query qualquer do tipo Heroi
            IQueryable<Heroi> consultaHerois = this.Context.Herois;
            consultaHerois = consultaHerois.OrderBy(h => h.IdHeroi).Where(Heroi => Heroi.IdHeroi == IdHeroi);
            return consultaHerois.ToArray();
            // aqui efetivamente ocorre o SELECT no BD
            //return await consultaHerois.FirstOrDefaultAsync();
        }

        public async Task<Usuario[]> GetAllUsuarios()
        {
            IQueryable<Usuario> consultaUsuarios = this.Context.Usuarios;
            consultaUsuarios = consultaUsuarios.OrderBy(u => u.cod_usuario);
            return consultaUsuarios.ToArray();
        }

        public Usuario[] GetUsuarioById(int cod)
        {
            IQueryable<Usuario> consultaUsuarios = this.Context.Usuarios;
            consultaUsuarios = consultaUsuarios.Where(Usuario => Usuario.cod_usuario == cod);
            return consultaUsuarios.ToArray();
        }

        public Usuario[] GetCodigoUsuario(string email, string senha)
        {
            System.Console.WriteLine(email);
            System.Console.WriteLine(senha);
            IQueryable<Usuario> consultaUsuario = this.Context.Usuarios;
            consultaUsuario = consultaUsuario
            .Where(u => u.email.Equals(email)); //compara o email dos usuarios do banco com o email do usuario passado
                                                //eh possivel que um usuario tenha mais de uma conta, entao comparar a 
                                                //senha tambem eh necessario
            consultaUsuario = consultaUsuario
            .Where(u => u.senha.Equals(senha));

            return consultaUsuario.ToArray();
        }

        public Heroi[] GetHeroisDoUsuario(int cod_usuario)
        {
            IQueryable<Heroi> consultaHerois = this.Context.Herois;
            consultaHerois = consultaHerois.Where(h => h.cod_usuario == cod_usuario);
            return consultaHerois.ToArray();
        }
    }
}