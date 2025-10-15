using Microsoft.EntityFrameworkCore;
using Onion_Application.Services;
using Onion_Domain.Interfaces;
using Onion_Domain.Servises;
using Onion_Infrastructure.Data;
using Onion_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Onion;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserAppService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
