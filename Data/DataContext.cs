using ControleDeConteudo.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeConteudo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<PerguntasFrequentes> PerguntasFrequentes { get; set; }
        public DbSet<BannerPrincipal> BannerPrincipal { get; set; }

        public DbSet<BannerDestaque> BannerDestaque { get; set; }
    }
}