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
                },
                new IssuePriority
                {
                    Id = 2,
                    Name = "Medium",
                },
                new IssuePriority
                {
                    Id = 3,
                    Name = "High",
                },
                new IssuePriority
                {
                    Id = 4,
                    Name = "Critical",
                });
        }
    }
}
