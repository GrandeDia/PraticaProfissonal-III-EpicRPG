using System.Threading.Tasks;
using ProjetoEpicRPGAPI.Models;

namespace ProjetoEpicRPGAPI.Data
{
    public interface IRepository
    {
        // Métodos genéricos
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Métodos GET, que não são genéricos, pois possuem algo específico, no caso, Aluno!
        Task<Heroi[]> GetAllHeroisAsync();
        Task<Heroi> GetAllHeroisAsyncByRa(int RA);
    }
}