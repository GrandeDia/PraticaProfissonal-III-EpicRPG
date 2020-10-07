using Microsoft.EntityFrameworkCore;
using ProjetoEpicRPGAPI.Models;

namespace ProjetoEpicRPGAPI.Data
{
    
    public class DungeonContext : DbContext
    {
        public DungeonContext(DbContextOptions<DungeonContext> options) : base(options)
        {

        }
        
        public DbSet<Heroi> Herois {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
    }
}