using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SegurosApp.Models;

namespace SegurosApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Seguradora> Seguradoras { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Seguro> Seguros { get; set; }  
    }
}
