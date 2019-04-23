using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ApplicantTestMVC.Models
{
    public class ApplicantTestMVCContext : DbContext
    {
        public ApplicantTestMVCContext() : base("backup_app_test")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicantTestMVCContext, Migrations.Configuration>());
        }

        static ApplicantTestMVCContext()
        {

        }

        public static ApplicantTestMVCContext Create()
        {
            return new ApplicantTestMVCContext();
        }
        
        public DbSet<user> user { get; set; }
        public DbSet<line_item> line_item { get; set; }
        public DbSet<order> order { get; set; }
        public DbSet<stock> stock { get; set; }
        public DbSet<unit> unit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}