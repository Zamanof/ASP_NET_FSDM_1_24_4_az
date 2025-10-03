using ASP_20._Logging_Cashing;
using ASP_20._Logging_Cashing.Data;
using ASP_20._Logging_Cashing.DTOs.Auth;
using ASP_20._Logging_Cashing.DTOs.Validation;
using ASP_20._Logging_Cashing.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AuthenticationAndAuthorization(builder.Configuration);

builder.Services.AddSwagger();

builder.Services.AddScoped<IToDoService, ToDoService>();

var connectionString = builder.Configuration
                                .GetConnectionString("TODO_DBContext");

builder.Services.AddDbContext<ToDoContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    }
    );

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddCors(
    opt=> opt.AddPolicy("CORSPolicy",
    builder =>
    {
        builder.AllowAnyMethod()
               .AllowAnyHeader()
               .WithOrigins("http://localhost:5173")
               .AllowCredentials();
    })
    );

//builder.Services
//    .AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
//builder.Services
//    .AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

//builder.Services.AddLogging(s=>
//{
//    s.SetMinimumLevel(LogLevel.Error);
//    //s.AddJsonConsole();
//});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .Enrich.WithProcessName()
    .Enrich.WithThreadName()
    .Enrich.WithThreadId()
    .WriteTo.Console(outputTemplate:
    "[{Timestamp: yyyy:MM:dd HH:mm:ss} {Level:u3}] {Message:lj} {NewLine}" +
    "ThreadId: {ThreadId}{NewLine}" +
    "ProcessName: {ProcessName} {NewLine} {Exception}{NewLine}{NewLine}"
    )
    .WriteTo.MSSqlServer(restrictedToMinimumLevel: LogEventLevel.Error, 
    connectionString: connectionString,
    sinkOptions: new MSSqlServerSinkOptions { TableName="LogEvents"})
    //.WriteTo.File("logs/myapp.txt", rollingInterval:RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x=> x.EnablePersistAuthorization());
}

//app.UseSerilogRequestLogging();

//app.UseResponseCaching();

app.UseCors("CORSPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Cashing