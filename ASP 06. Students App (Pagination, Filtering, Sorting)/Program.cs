using ASP_06._Students_App__Pagination__Filtering__Sorting_.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentAppContext>(o =>
        o.UseSqlServer(
            builder
            .Configuration
            .GetConnectionString("StudentAppContext"),
            s =>
            {
                s.CommandTimeout(30);
                s.MigrationsHistoryTable("EF_TABLE_MIGRATIONS");
            }
            )
);

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
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
