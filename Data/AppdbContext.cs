using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlogApi.Data;

public class AppdbContext : DbContext
{
    public AppdbContext(DbContextOptions<AppdbContext> options) : base(options) { }
    public DbSet<Category> categories{ get; set; } 
    public DbSet<Blog> blogs { get; set; }

}