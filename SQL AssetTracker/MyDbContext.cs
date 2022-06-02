using Microsoft.EntityFrameworkCore;

namespace SQL_AssetTracker
{
    public class MyDbContext : DbContext
    {
        public DbSet<AssetTracking> Assets { get; set; }
        
        // Change connection string here
        string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Assets;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
