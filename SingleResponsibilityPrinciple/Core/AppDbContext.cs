using Microsoft.Data.Entity;

namespace SingleResponsibilityPrinciple.Core
{
    
    public class AppDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionString);

        }
    }

    public class AppSettings
    {
        public static string ConnectionString { get; set; }
    }
}