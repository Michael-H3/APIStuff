using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIStuff.Models
{
    /// <summary>
    /// Database "connection " and all the tables virtually
    /// </summary>
    public class DatabaseContext : DbContext
    {
        //det kan vi lige tale om senere DI
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // Database.EnsureCreated() // ver 2.1
            //Database.EnsureCreated
            //Database.Migrate();
        }

        //public DbSet<className> yourTableName { get; set; }
        public DbSet<Samurai> Samurai { get; set; }
        public DbSet<Battle> Battle { get; set; }

        public List<SamuraisInBattle> SamuraisInBattle { get; set; }

        public DbSet<ActionHeroes> ActionHeroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraisInBattle>().HasKey(relation => new
            {
                relation.samuraiID,
                relation.battleID
            });
        }


    }
}
