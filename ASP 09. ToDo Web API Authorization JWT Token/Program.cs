using ASP_09._ToDo_Web_API_Authorization_JWT_Token.Data;
using ASP_09._ToDo_Web_API_Authorization_JWT_Token.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = "https://localhost:5069",
            ValidAudience = "https://localhost:5069",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("En bomba achar"))
        };
    });



builder.Services.AddSwaggerGen(
    setup =>
    {
        setup.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ToDo",
                Version = "v 2.0",
            });
        setup
        .IncludeXmlComments(@"obj\Debug\net8.0\ASP 09. ToDo Web API Authorization JWT Token.xml");
        setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT"
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
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddDbContext<ToDoContext>(
    options =>
    {
        options.UseSqlServer(
            builder.Configuration
                                .GetConnectionString("TODO_DBContext"));
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
