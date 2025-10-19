#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NGRI.Library.Model;

namespace NGRI.Webapi.Data
{
    public class NGRIWebapiContext : DbContext
    {
        public string DbPath { get; }
        private static bool _created = false;
        
        private static bool _created = false;

        public NGRIWebapiContext (DbContextOptions<NGRIWebapiContext> options): base(options)
        {

            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
            
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Ngri.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}", b => b.MigrationsAssembly("NGRI.Webapi"));
        }

        public DbSet<Estate> Estates { get; set; }

        public DbSet<ConditionReport> ConditionReports { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estate>().HasKey(e => e.Id);
            modelBuilder.Entity<ConditionReport>().HasKey(e => e.Id);

            modelBuilder.Entity<Estate>().HasMany(e => e.ConditionReports).WithOne(c => c.Estate);
        }
    }
}
