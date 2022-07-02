using Microsoft.EntityFrameworkCore;
using Movie.Entity;
namespace Movie.Data;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option):base(option){}
    
    public DbSet<Movies> Movie{get;set;}
}