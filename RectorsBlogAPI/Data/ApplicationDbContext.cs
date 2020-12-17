using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RectorsBlogAPI.Features.Categories.Models;
using RectorsBlogAPI.Features.Comments.Models;
using RectorsBlogAPI.Features.Identity.Models;
using RectorsBlogAPI.Features.Posts.Models;

namespace RectorsBlogAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Unique category names
            builder.Entity<Category>()
                .HasIndex(c => c.CategoryName)
                .IsUnique();

            // post has one user, which has many posts
            builder.Entity<Post>()
                .HasOne<ApplicationUser>(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // comment has one post, which has many comments
            builder.Entity<Comment>()
                .HasOne<Post>(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            // comment has one user, which has many comments
            builder.Entity<Comment>()
                .HasOne<ApplicationUser>(c => c.Author)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // many to many for PostCategory
            builder
                .Entity<PostCategory>()
                .HasKey(pc => new 
                { 
                    pc.PostId, 
                    pc.CategoryId 
                });
            builder.Entity<PostCategory>()
                .HasOne<Post>(pc => pc.Post)
                .WithMany(p => p.PostCategories)
                .HasForeignKey(pc => pc.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PostCategory>()
                .HasOne<Category>(pc => pc.Category)
                .WithMany(c => c.PostCategories)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
