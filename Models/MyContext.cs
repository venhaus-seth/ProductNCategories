#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ProductNCategories.Models; // fill in ProjectName
public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    // create the following line for every model
    public DbSet<Product> Products { get; set; } 
    public DbSet<Category> Categories { get; set; } 
    public DbSet<Connection> Connections { get; set; } 
}