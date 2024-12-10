using BugTracker.Identity.DbContext;
using BugTracker.Persistence.DatabaseContext;
using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;

namespace BugTracker.Api.IntegrationTests
{
    public class BugTrackerApiFactory : WebApplicationFactory<IApiMarker>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("bugtrackeridentity")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(5432))
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<BugTrackerIdentityDbContext>();
                services.AddDbContext<BugTrackerIdentityDbContext>(options =>
                {
                    options.UseNpgsql(_dbContainer.GetConnectionString());
                });
            });
        }
        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
            using var scope = Services.CreateScope();
            var dbContextIdentity = scope.ServiceProvider.GetRequiredService<BugTrackerIdentityDbContext>();

            // Workaround for a bug in Npgsql: Running a migration on an empty database fails.
            // For details, see: https://github.com/npgsql/npgsql/issues/852
            await dbContextIdentity.Database.ExecuteSqlRawAsync(
                @"CREATE TABLE ""__EFMigrationsHistory""
                (""MigrationId"" text NOT NULL,
                ""ProductVersion"" text NOT NULL,
                CONSTRAINT ""PK_HistoryRow"" PRIMARY KEY (""MigrationId""))");

            await dbContextIdentity.Database.MigrateAsync();
        }

        public async new Task DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }

    }
}
