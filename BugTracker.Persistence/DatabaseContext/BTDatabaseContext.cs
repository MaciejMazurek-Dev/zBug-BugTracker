using BugTracker.Domain;
using BugTracker.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Persistence.DatabaseContext
{
    public class BTDatabaseContext : DbContext
    {
        public BTDatabaseContext(DbContextOptions<BTDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssuePriority> IssuePriorities { get; set; }
        public DbSet<IssueStatus> IssueStatuses { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BTDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.UtcNow;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }
            }
        
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
