using Microsoft.EntityFrameworkCore;

namespace API1.Models;

public class ContextDB :DbContext
{
    
    public ContextDB(DbContextOptions<ContextDB> options) : base(options)

    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users {get; set; }
}