using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext:DbContext
    {
            public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
            public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
            public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
            public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
            public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
            public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
            public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
            public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
            public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
            public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
            public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
            public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
            public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
            public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
            public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
            public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
            public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
            public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
            public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

        
        public CareerCloudContext():base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {
                
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Start ApplicantProfilePoco 
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantEducations)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantResumes)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(e => e.ApplicantSkills)
               .WithRequired(e => e.ApplicantProfiles)
               .HasForeignKey(e => e.Applicant)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(e => e.ApplicantWorkHistorys)
               .WithRequired(e => e.ApplicantProfiles)
               .HasForeignKey(e => e.Applicant)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(e => e.ApplicantJobApplication)
               .WithRequired(e => e.ApplicantProfiles)
               .HasForeignKey(e => e.Applicant)
               .WillCascadeOnDelete(false);
            //End ApplicantProfilePoco

            //Start CompanyJobPoco
            modelBuilder.Entity<CompanyJobPoco>()
               .HasMany(e => e.CompanyJobEducations)
               .WithRequired(e => e.CompanyJobs)
               .HasForeignKey(e => e.Job)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
               .HasMany(e => e.CompanyJobSkills)
               .WithRequired(e => e.CompanyJobs)
               .HasForeignKey(e => e.Job)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
               .HasMany(e => e.CompanyJobDescriptions)
               .WithRequired(e => e.CompanyJobs)
               .HasForeignKey(e => e.Job)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
               .HasMany(e => e.ApplicantJobApplications)
               .WithRequired(e => e.CompanyJobs)
               .HasForeignKey(e => e.Job)
               .WillCascadeOnDelete(false);
            //End CompanyJobPoco
            //Start CompanyProfilePoco
            modelBuilder.Entity<CompanyProfilePoco>()
               .HasMany(e => e.CompanyDescriptions)
               .WithRequired(e => e.CompanyProfiles)
               .HasForeignKey(e => e.Company)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
              .HasMany(e => e.CompanyJobs)
              .WithRequired(e => e.CompanyProfiles)
              .HasForeignKey(e => e.Company)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
              .HasMany(e => e.CompanyLocations)
              .WithRequired(e => e.CompanyProfiles)
              .HasForeignKey(e => e.Company)
              .WillCascadeOnDelete(false);
            //End CompanyProfilePoco
            //Start SecurityLoginPoco
            modelBuilder.Entity<SecurityLoginPoco>()
              .HasMany(e => e.ApplicantProfiles)
              .WithRequired(e => e.SecurityLogins)
              .HasForeignKey(e => e.Login)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
              .HasMany(e => e.SecurityLoginsLogs)
              .WithRequired(e => e.SecurityLogins)
              .HasForeignKey(e => e.Login)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
              .HasMany(e => e.SecurityLoginsRoles)
              .WithRequired(e => e.SecurityLogins)
              .HasForeignKey(e => e.Login)
              .WillCascadeOnDelete(false);
            //End SecurityLoginPoco
            //Start SecurityRolePoco
            modelBuilder.Entity<SecurityRolePoco>()
              .HasMany(e => e.SecurityLoginsRoles)
              .WithRequired(e => e.SecurityRoles)
              .HasForeignKey(e => e.Role)//Login?
              .WillCascadeOnDelete(false);
            //End SecurityRolePoco
            //Start SystemCountryCodePoco
            modelBuilder.Entity<SystemCountryCodePoco>()
              .HasMany(e => e.ApplicantProfiles)
              .WithRequired(e => e.SystemCountryCode)
              .HasForeignKey(e => e.Country)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemCountryCodePoco>()
              .HasMany(e => e.ApplicantWorkHistory)
              .WithRequired(e => e.SystemCountryCodes)
              .HasForeignKey(e => e.CountryCode)
              .WillCascadeOnDelete(false);
            //End SystemCountryCodePoco
            //Start SystemLanguageCodePoco
                modelBuilder.Entity<SystemLanguageCodePoco>()
              .HasMany(e => e.CompanyDescriptions)
              .WithRequired(e => e.SystemLanguageCodes)
              .HasForeignKey(e => e.LanguageId)
              .WillCascadeOnDelete(false);
            //End SystemLanguageCodePoco

            base.OnModelCreating(modelBuilder);
        }


    }
}
