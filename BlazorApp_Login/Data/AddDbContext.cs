using Microsoft.EntityFrameworkCore;

namespace BlazorApp_Login.Data;
public class AddDbContext:DbContext
{
    public AddDbContext(DbContextOptions<AddDbContext> options):base(options) { }
    public DbSet<User> User { get; set; }
}
