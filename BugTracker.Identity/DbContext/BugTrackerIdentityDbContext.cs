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
    }
}
