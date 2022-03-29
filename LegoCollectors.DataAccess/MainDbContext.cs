using LegoCollectors.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LegoCollectors.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        
        public virtual DbSet<LegoEntity> Legos { get; set; }
    }
}