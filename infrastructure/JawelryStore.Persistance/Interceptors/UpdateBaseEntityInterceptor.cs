using JewelryStore.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.Interceptors
{
    public class UpdateBaseEntityInterceptor:SaveChangesInterceptor
    {

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            var dbContext = eventData.Context;

            if (dbContext == null)
            {
                return base.SavedChangesAsync(eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<BaseEntity>> entries = dbContext
                .ChangeTracker
                .Entries<BaseEntity>();

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        if (entityEntry.Property(x => x.CreatedDate).CurrentValue == default(DateTime))
                        {
                            entityEntry.Property(x => x.CreatedDate).CurrentValue = DateTime.UtcNow;
                        }
                        break;

                    case EntityState.Modified:
                        if (entityEntry.Property(x => x.UpdatedDate).CurrentValue == null || entityEntry.Property(x => x.UpdatedDate).CurrentValue == default(DateTime))
                        {
                            entityEntry.Property(x => x.UpdatedDate).CurrentValue = DateTime.UtcNow;
                        }
                        break;
                }
            }

            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}
