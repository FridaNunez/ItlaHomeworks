using Microsoft.EntityFrameworkCore;
using PlantStore.model;

namespace PlantStore.dbcontext
{
    public class TiendaContext : DbContext
    {
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoPlanta> PedidoPlantas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=ANTHONYX360\\SQLEXPRESS;Database=TiendaPlantasDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoPlanta>()
                .HasKey(pp => new { pp.PedidoId, pp.PlantaId });
        }
    }
}



