using exercise.wwwapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace exercise.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;
        public DatabaseContext()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().Navigation(x => x.Comments).AutoInclude();
            modelBuilder.Entity<Comment>().Navigation(x => x.BlogPost).AutoInclude();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseNpgsql(_connectionString);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follows> Follows { get; set; }




    }
}




