using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fc.Data.Implementations;
using Fc.Entities.Abstractions;
using Fc.Entities.Domain;
using Fc.Infraestructure.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Fc.Data.Definitions
{
    public class Context : DbContext, IContext
    {
        private readonly IDbSettingsProvider _connectionStringProvider;

        public Context(IDbSettingsProvider connectionStringProvider) : base(
            new DbContextOptions<Context>())
        {
            _connectionStringProvider = connectionStringProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseInMemoryDatabase(_connectionStringProvider.DatabaseName);

            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CheckAudit();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void CheckAudit()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity
                            && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                if (!(entry.Entity is BaseEntity entity)) continue;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = "admin"; //Test purpose
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                    entity.UpdatedBy = "admin"; //Test purpose
                    entity.UpdatedOn = DateTime.Now;
                }
            }
        }

        public DbSet<Image> Images { get; set; }
    }
}
