using Microsoft.EntityFrameworkCore;
using rede_social_api_at.Models;

namespace rede_social_api_at.DbContextConfig
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Usuario>().HasKey(t => t.Id);

        }
        
    }
}