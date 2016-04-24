using Microsoft.Data.Entity;

namespace ContactManager.Core
{
    public class AppDbContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionString);

        }
    }
}