using Microsoft.EntityFrameworkCore;

namespace HW11.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cache> Caches { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    }
}