using System.ComponentModel;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.DatabaseContext {
    public class AppDbContext : DbContext {

        public DbSet<Blog> Blogs { get; set; } = default!;

        public DbSet<Comment> Comments { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Rating> Ratings { get; set; } = default!;
        
        // Join table for reference access
        public DbSet<ProductRating> ProductRatings { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);
            
            modelBuilder.Entity<Product>()
                .HasOne<Category>()
                .WithMany()       
                .HasForeignKey(p => p.Category_Id);
            
            // This joint table provides navigation properties to EF so it can be accessed inside the same context
            modelBuilder.Entity<ProductRating>()
                .HasKey(pr => new { pr.ProductId, pr.RatingId }); // Composite primary key

            modelBuilder.Entity<ProductRating>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.ProductRatings) // Reference to joint table
                .HasForeignKey(pr => pr.ProductId);

            modelBuilder.Entity<ProductRating>()
                .HasOne(pr => pr.Rating)
                .WithMany(r => r.ProductRatings) // Reference to joint table
                .HasForeignKey(pr => pr.RatingId);

            
        }
        
    }
}
