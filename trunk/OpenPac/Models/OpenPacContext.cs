using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpenPac.Models
{
    public class OpenPacContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<OpenPac.Models.OpenPacContext>());

        public DbSet<OpenPac.Models.Candidate> Candidates { get; set; }

        public DbSet<OpenPac.Models.CandidateIssue> CandidateIssues { get; set; }

        public DbSet<OpenPac.Models.District> Districts { get; set; }

        public DbSet<OpenPac.Models.DistrictIssue> DistrictIssues { get; set; }

        public DbSet<OpenPac.Models.Education> Educations { get; set; }

        public DbSet<OpenPac.Models.Issue> Issues { get; set; }

        public DbSet<OpenPac.Models.MediaOutlet> MediaOutlets { get; set; }

        public DbSet<OpenPac.Models.MediaOutletIssue> MediaOutletIssues { get; set; }

        public DbSet<OpenPac.Models.WorkExperience> WorkExperiences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>().Property(d => d.Latitude).HasPrecision(9, 6);
            modelBuilder.Entity<District>().Property(d => d.Longitude).HasPrecision(9, 6);

            base.OnModelCreating(modelBuilder);
        }
    }
}