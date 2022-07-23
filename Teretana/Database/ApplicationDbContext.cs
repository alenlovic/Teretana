using Microsoft.EntityFrameworkCore;
using Teretana.Models;

namespace Teretana.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TreneriModel> Treneri { get; set; }
        public DbSet<ClanoviModel> Clanovi { get; set; }
    }
}
