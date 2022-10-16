using lms.Application.Services.Authentication;
using lms.Application.Services.Courses;
using Microsoft.Extensions.DependencyInjection;

namespace lms.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICoursesService, CoursesService>();
        return services;
    }
}