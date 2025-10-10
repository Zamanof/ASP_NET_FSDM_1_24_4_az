using ASP_22._Background_Workers.Auth;
using ASP_22._Background_Workers.Data;
using ASP_22._Background_Workers.Models;
using ASP_22._Background_Workers.Providers;
using ASP_22._Background_Workers.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ASP_22._Background_Workers;

public static class DI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
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
        var filePath = Path.Combine(AppContext.BaseDirectory, "Documentation.xml");
        setup
        .IncludeXmlComments(filePath);
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

    public static IServiceCollection AuthenticationAndAuthorization(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {

        services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ToDoContext>();

        services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<IRequestUserProvider, RequestUserProvider>();


        var jwtConfig = new JwtConfig();
        configuration.Bind("JWT", jwtConfig);
        services.AddSingleton(jwtConfig);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret))
        };
    });

        services.AddAuthorization(
            options =>
            {

                options.AddPolicy("CanTest", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    //policy.RequireClaim("CanTest");
                    policy.Requirements.Add(new CanTestRequirment());
                });
            });

        return services;
    }

    // extension methods
    // AuthenticationAndAuthorization

}
