using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChangeManagementInventory.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=ChangeManagementInventory") { }
        public DbSet<Application> Applications { get; set; }
        public DbSet<AppLicenseType> AppLicenseTypes { get; set; }
        public DbSet<AppType> AppTypes { get; set; }
        public DbSet<Company> Companies { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Seed AppLicenseType
        //    modelBuilder.Entity<AppLicenseType>().;
        //}


    }
}