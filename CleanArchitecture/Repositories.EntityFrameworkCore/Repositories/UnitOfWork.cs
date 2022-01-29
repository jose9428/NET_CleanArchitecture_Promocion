using Entities.Interfaces;
using Repositories.EntityFrameworkCore.DataContext;
using System.Threading.Tasks;

namespace Repositories.EntityFrameworkCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DatabaseContext DatabaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
            => DatabaseContext = databaseContext;

        public Task<int> SaveChangesAsync()
        {
            return DatabaseContext.SaveChangesAsync();
        }
    }
}
