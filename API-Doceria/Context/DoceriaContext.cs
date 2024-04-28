using API_Doceria.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Doceria.Context
{
    public class DoceriaContext : DbContext
    {
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Historico_Ingrediente> Historico_Ingredientes { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Receita_Ingrediente> Receita_Ingrediente { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pedido_Receita> Pedido_Receitas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DoceriaContext(DbContextOptions<DoceriaContext> options) : base(options)
        {

        }
    }
}
