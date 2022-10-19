using lms.Application.Common.Interfaces.Authentication;
using lms.Application.Common.Interfaces.Services;
using lms.Infrastructure.Authentication;
using lms.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using lms.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.EntityFrameworkCore;
using lms.Infrastructure.Persistence.AppSettings;

namespace lms.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var connectionStrings = new ConnectionStrings();
        configuration.Bind(ConnectionStrings.SectionName, connectionStrings);

        services.AddSingleton(Options.Create(connectionStrings));

        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserDbContext, UserDbContext>();
        services.AddScoped<ICoursesRepository, CoursesRepository>();

        ///* Database context DI - local */
        //var dbHost = @"(LocalDb)\MSSQLLocalDB";
        //var dbName = "lms";
        //var ConnectionString = $"Data Source={dbHost};Initial Catalog={dbName};";
        //services.AddDbContext<UserDbContext>(opt => opt.UseSqlServer(ConnectionString));
        ///* ========================= */

        /* Database context DI */
        //var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        //var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        //var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
        //var ConnectionString = $"Data Source={dbHost};Initial Catalog={dbName}; User ID=sa; Password={dbPassword}";
        var sqlConnectionString = connectionStrings.Sql;
        services.AddDbContext<UserDbContext>(opt => opt.UseSqlServer(sqlConnectionString));
        /* ========================= */

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret)
            )
        });

        return services;
    }
}