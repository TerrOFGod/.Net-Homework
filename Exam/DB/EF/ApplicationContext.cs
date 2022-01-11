using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Enemy> Monsters { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var m1 = new Enemy
            {
                Id = 5,
                Name = "Rhinoceros",
                HP = 45,
                AttackModifier = 7,
                AttackPerRound = 1,
                Damage = "2d8",
                DamageModifier = 5,
                AC = 11
            };

            var m2 = new Enemy
            {
                Id = 6,
                Name = "Mage",
                HP = 40,
                AttackModifier = 3,
                AttackPerRound = 4,
                Damage = "1d4",
                DamageModifier = 2,
                AC = 12
            };

            var m3 = new Enemy
            {
                Id = 7,
                Name = "Cat",
                HP = 2,
                AttackModifier = 0,
                AttackPerRound = 1,
                Damage = "1d1",
                DamageModifier = 0,
                AC = 12
            };
            
            var m4 = new Enemy
            {
                Id = 8,
                Name = "Ice Frog",
                HP = 32,
                AttackModifier = 3,
                AttackPerRound = 1,
                Damage = "1d8",
                DamageModifier = 1,
                AC = 12
            };

            modelBuilder.Entity<Enemy>().HasData(m1, m2, m3, m4);
            base.OnModelCreating(modelBuilder);
        }
    }
}