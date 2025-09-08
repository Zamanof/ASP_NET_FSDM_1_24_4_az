using ASP_09._ToDo_Web_API_Authorization_JWT_Token.Data;
using ASP_09._ToDo_Web_API_Authorization_JWT_Token.DTOs.Auth;
using ASP_09._ToDo_Web_API_Authorization_JWT_Token.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ElektrikleshdirebildiklerimizdensinizmiElektrikleshdirebildiklerimizdensinizmi"))
        };
    });

builder.Services.AddAuthorization(
    options =>
    {
        options.AddPolicy("CanTest", policy =>
        {
            policy.RequireAuthenticatedUser();
            //policy.RequireClaim("CanTest");
            policy.Requirements.Add(new CanTestRequirment());
        });
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
    app.UseSwaggerUI(x=> x.EnablePersistAuthorization());
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
