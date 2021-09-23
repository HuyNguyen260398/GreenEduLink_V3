using GEL.Services.PostAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GEL.Services.PostAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Post> Posts { get; set; }
}