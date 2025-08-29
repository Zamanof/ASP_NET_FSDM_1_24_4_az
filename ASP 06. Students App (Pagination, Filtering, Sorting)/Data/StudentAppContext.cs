using ASP_06._Students_App__Pagination__Filtering__Sorting_.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_06._Students_App__Pagination__Filtering__Sorting_.Data;

public class StudentAppContext : DbContext
{
    public StudentAppContext(DbContextOptions<StudentAppContext> options) 
        : base(options)
    {}

    public DbSet<Student> Students { get; set; } = default!;
 }
