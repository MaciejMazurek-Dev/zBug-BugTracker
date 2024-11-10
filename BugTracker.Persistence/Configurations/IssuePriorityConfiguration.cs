using BugTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugTracker.Persistence.Configurations
{
    public class IssuePriorityConfiguration : IEntityTypeConfiguration<IssuePriority>
    {
        public void Configure(EntityTypeBuilder<IssuePriority> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasData(
                new IssuePriority
                {
                    Id = 1,
                    Name = "Low",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new IssuePriority
                {
                    Id = 2,
                    Name = "Medium",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new IssuePriority
                {
                    Id = 3,
                    Name = "High",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new IssuePriority
                {
                    Id = 4,
                    Name = "Critical",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                });
        }
    }
}
