using Bespereboiniki.Datalayer.Tables;
using Microsoft.EntityFrameworkCore;

namespace Bespereboiniki.Datalayer
{
    public class UPSContext : DbContext
    {
        public UPSContext(DbContextOptions<UPSContext> options) : base(options)
        {
        }

        public UPSContext()
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        
        // for migrations
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=localhost,1433;Database=Besperiboiniki_Db;User ID=SA;Password=Pass@word;Integrated Security=False;Trusted_Connection=False; MultipleActiveResultSets=true");
        }

        public DbSet<UPS> UPSes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }
    }
}