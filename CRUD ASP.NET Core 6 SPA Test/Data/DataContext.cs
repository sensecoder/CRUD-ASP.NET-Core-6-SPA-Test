using CRUD_ASP.NET_Core_6_SPA_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ASP.NET_Core_6_SPA_Test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> Options) : base(Options) { }
        public DbSet<EntityObject> EntityObjects { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<EntityObject>().ToTable("EntityObject");
        }
    }
}
