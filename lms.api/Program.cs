using lms.Application;
using lms.Infrastructure;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Standard Authorization Header (\"bearer {token}\")",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    //builder.Services.AddCors(x => x.AddPolicy("corspolicy", y =>
    //{
    //    //dev
    //    //y.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    //    //prod
    //    y.WithOrigins("https://lmsapiapi.azure-api.net").AllowAnyMethod().AllowAnyHeader();
    //}));
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "LMS - API - V1");
        c.RoutePrefix = String.Empty;
    });
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "LMS - API - V1");
            //c.RoutePrefix = String.Empty;
        });
    }
    //app.UseCors("corspolicy");
    app.UseHttpsRedirection();

    //app.UseAuthentication();
    //app.UseAuthorization();

    app.MapControllers();

    app.Run();
}


