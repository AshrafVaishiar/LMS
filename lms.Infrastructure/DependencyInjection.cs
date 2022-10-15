using lms.Application.Common.Interfaces.Authentication;
using lms.Application.Common.Interfaces.Services;
using lms.Infrastructure.Authentication;
using lms.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using lms.Application.Common.Interfaces.Persistence;
using lms.Infrastructure.Persistence;

namespace lms.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        ConfigurationManager configuration) {
        
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}