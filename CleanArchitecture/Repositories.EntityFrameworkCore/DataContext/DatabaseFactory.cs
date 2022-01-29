using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repositories.EntityFrameworkCore.DataContext
{
    internal class DatabaseFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DatabaseContext> optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            //optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=CleanArchExampleDB");
            optionBuilder.UseSqlServer("Server=.;Initial Catalog=CleanArchExampleDB;Persist Security Info=False;User ID=sa;Password=castro;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new DatabaseContext(optionBuilder.Options);
        }
    }
}
