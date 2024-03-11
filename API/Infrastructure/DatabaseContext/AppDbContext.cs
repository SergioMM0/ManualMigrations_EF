using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.DatabaseContext {
    public class AppDbContext : DbContext {

        public DbSet<Blog> Blogs { get; set; } = default!;

        public DbSet<Comment> Comments { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            /*
             modelBuilder.Entity<Blog>()
                .HasMany(b => b.Comments)
                .WithOne()
                .HasForeignKey("BlogId")
                .IsRequired();

            modelBuilder.Entity<Blog>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Comment>()
                .Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(500);
                
        }
        */
    }
}
