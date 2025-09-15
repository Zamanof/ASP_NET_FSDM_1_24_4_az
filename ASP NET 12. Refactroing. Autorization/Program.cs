using ASP_NET_12._Refactroing._Autorization;
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

builder.Services.AuthenticationAndAuthorization(builder.Configuration);

builder.Services.AddSwagger();

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
