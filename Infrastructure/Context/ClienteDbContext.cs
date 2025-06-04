using CustomerApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Infrastructure.Context
{
    public class ClienteDbContext : DbContext
    {
        public DbSet<Cliente> Customers => Set<Cliente>();

        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().OwnsOne(c => c.Endereco);
            modelBuilder.Entity<Cliente>().HasIndex(c => c.Email).IsUnique();
        }
    }

}
