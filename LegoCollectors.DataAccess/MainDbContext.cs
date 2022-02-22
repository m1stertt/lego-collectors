using Microsoft.EntityFrameworkCore;

namespace ScrumMasters.Webshop.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}