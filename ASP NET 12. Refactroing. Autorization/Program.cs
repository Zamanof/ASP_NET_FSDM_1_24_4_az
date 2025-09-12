using ASP_NET_12._Refactroing._Autorization.Auth;
using ASP_NET_12._Refactroing._Autorization.Data;
using ASP_NET_12._Refactroing._Autorization.DTOs.Auth;
using ASP_NET_12._Refactroing._Autorization.Models;
using ASP_NET_12._Refactroing._Autorization.Services;
using ASP_NET_12._Refactroing._Autorization.Services.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IJwtService, JwtService>();

var jwtConfig = new JwtConfig();
builder.Configuration.Bind("JWT", jwtConfig);
builder.Services.AddSingleton(jwtConfig);

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ToDoContext>();


// builder.Services.AuthenticationAndAuthorization(builder.Configuration);
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
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
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

        options.AddPolicy("CanCreate", policy =>
        {
            policy.RequireAuthenticatedUser();
            //policy.RequireClaim("CanTest");
            policy.Requirements.Add(new CanCreateRequirment());
        });
        options.AddPolicy("SomeRequirment", policy =>
        {
            policy.RequireAuthenticatedUser();
            //policy.RequireClaim("CanTest");
            policy.Requirements.Add(new CanTestRequirment());
            policy.Requirements.Add(new CanCreateRequirment());
        });
    });


builder.Services.AddSwaggerGen();

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
