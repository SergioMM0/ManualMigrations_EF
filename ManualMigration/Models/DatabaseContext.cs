using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ManualMigration.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public string DbPath { get; }

        // Constructor to configure database connection
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "ECommerceDatabase.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
