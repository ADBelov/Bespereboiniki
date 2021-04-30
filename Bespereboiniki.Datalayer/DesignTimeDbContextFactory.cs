using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bespereboiniki.Datalayer
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<UPSContext>
    {
        public UPSContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UPSContext>();
            builder.UseSqlServer($"Server=localhost,1433;Database=Besperiboiniki_Db;User ID=SA;Password=Pass@word;Integrated Security=False");
            return new UPSContext(builder.Options);
        }
    }
}