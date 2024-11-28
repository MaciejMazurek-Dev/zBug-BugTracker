using BugTracker.Application.Models.Identity;
using BugTracker.Identity.DbContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BugTracker.Identity.Models;
using Microsoft.AspNetCore.Identity;
using BugTracker.Application.Contracts.Identity;
using BugTracker.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BugTracker.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<BugTrackerIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BTIdentityConnection")));

            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BugTrackerIdentityDbContext>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

            return services;
        }
    }
}
