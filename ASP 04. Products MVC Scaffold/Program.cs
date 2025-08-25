using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ASP_04._Products_MVC_Scaffold.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ASP_04_Products_MVC_ScaffoldContext>(options =>
    options.UseInMemoryDatabase("MYDB"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
