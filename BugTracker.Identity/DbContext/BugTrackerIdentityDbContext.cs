using BugTracker.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Identity.DbContext
{
    public class BugTrackerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public BugTrackerIdentityDbContext(DbContextOptions<BugTrackerIdentityDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BugTrackerIdentityDbContext).Assembly);
            builder.Entity<ApplicationUser>()
                .Property(p => p.InternalUserId)
                .ValueGeneratedOnAdd();
            base.OnModelCreating(builder);
        }
    }
}
