using System.Threading.Tasks;
using Fc.Infraestructure.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Fc.Infraestructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; }

        public async Task<int> Commit()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}