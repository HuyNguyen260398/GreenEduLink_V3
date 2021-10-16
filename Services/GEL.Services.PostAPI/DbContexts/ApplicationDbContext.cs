using GEL.Services.PostAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GEL.Services.PostAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().HasData(new Post
            {
                PostId = 1,
                Title = "Post 1",
                Description = "Desc 1",
                CategoryId = 1,
                SubCategoryId = 1,
                Slug = "Slug 1",
                Thumbnail = "",
                Content = "Content 1",
                CreatedAt = DateTime.Now,
                PublishedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Views = 1,
                Comments = 1
            });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                PostId = 2,
                Title = "Post 2",
                Description = "Desc 2",
                CategoryId = 2,
                SubCategoryId = 2,
                Slug = "Slug 2",
                Thumbnail = "",
                Content = "Content 2",
                CreatedAt = DateTime.Now,
                PublishedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Views = 2,
                Comments = 2
            });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                PostId = 3,
                Title = "Post 3",
                Description = "Desc 3",
                CategoryId = 3,
                SubCategoryId = 3,
                Slug = "Slug 3",
                Thumbnail = "",
                Content = "Content 3",
                CreatedAt = DateTime.Now,
                PublishedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Views = 3,
                Comments = 3
            });
        }
    }
}