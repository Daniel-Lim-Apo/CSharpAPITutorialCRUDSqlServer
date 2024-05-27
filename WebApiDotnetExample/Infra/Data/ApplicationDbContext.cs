using Microsoft.EntityFrameworkCore;
using WebApiDotnetExample.Model;

namespace WebApiDotnetExample.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}