using BugTracker.Application;
using BugTracker.Identity;
using BugTracker.Infrastructure;
using BugTracker.Persistence;

namespace BugTracker.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", config =>
                {
                    config.AllowAnyHeader();
                    config.AllowAnyOrigin();
                    config.AllowAnyMethod();
                });
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
