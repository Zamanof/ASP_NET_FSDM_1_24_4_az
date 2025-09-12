using Microsoft.OpenApi.Models;

namespace ASP_NET_12._Refactroing._Autorization;

public static class DI
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(
    setup =>
    {
        setup.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ToDo",
                Version = "v 2.0",
            });
        setup
        .IncludeXmlComments(@"obj\Debug\net8.0\ASP NET 11. Identity. Refresh token.xml");
        setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        });
        setup.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            }, new string[]{ }
            }
        });
    }
    );
        return services;
    }
    
    // extension methods
    // AuthenticationAndAuthorization
   
}
