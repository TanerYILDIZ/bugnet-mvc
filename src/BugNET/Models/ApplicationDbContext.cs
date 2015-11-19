using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace BugNET.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public virtual DbSet<ApplicationLog> ApplicationLog { get; set; }
        public virtual DbSet<DefaultValues> DefaultValues { get; set; }
        public virtual DbSet<DefaultValuesVisibility> DefaultValuesVisibility { get; set; }
        public virtual DbSet<HostSetting> HostSettings { get; set; }
        public virtual DbSet<IssueAttachment> IssueAttachments { get; set; }
        public virtual DbSet<IssueComment> IssueComments { get; set; }
        public virtual DbSet<IssueHistory> IssueHistory { get; set; }
        public virtual DbSet<IssueNotification> IssueNotifications { get; set; }
        public virtual DbSet<IssueRevision> IssueRevisions { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<IssueVote> IssueVotes { get; set; }
        public virtual DbSet<IssueWorkReport> IssueWorkReports { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Category> ProjectCategories { get; set; }
        public virtual DbSet<CustomField> ProjectCustomFields { get; set; }
        public virtual DbSet<CustomFieldSelection> ProjectCustomFieldSelections { get; set; }
        public virtual DbSet<CustomFieldType> ProjectCustomFieldTypes { get; set; }
        public virtual DbSet<CustomFieldValue> ProjectCustomFieldValues { get; set; }
        public virtual DbSet<IssueType> ProjectIssueTypes { get; set; }
        public virtual DbSet<ProjectMailbox> ProjectMailBoxes { get; set; }
        public virtual DbSet<Milestone> ProjectMilestones { get; set; }
        public virtual DbSet<ProjectNotification> ProjectNotifications { get; set; }
        public virtual DbSet<Priority> ProjectPriorities { get; set; }
        public virtual DbSet<Resolution> ProjectResolutions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatus { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        public virtual DbSet<QueryClause> QueryClauses { get; set; }
        public virtual DbSet<RelatedIssue> RelatedIssues { get; set; }
        public virtual DbSet<RequiredField> RequiredFieldList { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<DefaultValues>()
                .Property(e => e.IssueEstimation)
                .HasColumnType("decimal(5,2)");
            //.HasPrecision(5, 2);

            builder.Entity<Issue>()
                .Property(e => e.Estimation)
                .HasColumnType("decimal(5,2)");
            //.HasPrecision(5, 2);

            builder.Entity<Issue>()
                .HasMany(e => e.Votes)
                .WithOne(e => e.Issue)
                .HasForeignKey(e => e.IssueId);
            //.WillCascadeOnDelete(false);

            builder.Entity<Issue>()
                .HasMany(e => e.RelatedIssues)
                .WithOne(e => e.PrimaryIssue)
                .HasForeignKey(e => e.PrimaryIssueId);

            builder.Entity<Issue>()
                .HasMany(e => e.RelatedIssues1)
                .WithOne(e => e.SecondaryIssue)
                .HasForeignKey(e => e.SecondaryIssueId)
                .OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Restrict);

            builder.Entity<IssueWorkReport>()
                .Property(e => e.Duration)
                //.HasPrecision(4, 2);
                .HasColumnType("decimal(4,2)");

            builder.Entity<Category>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId);

            builder.Entity<CustomField>()
                .HasMany(e => e.ProjectCustomFieldValues)
                .WithOne(e => e.ProjectCustomFields)
                .OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Restrict);

            builder.Entity<Milestone>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Milestone)
                .HasForeignKey(e => e.MilestoneId);

            builder.Entity<Milestone>()
                .HasMany(e => e.Issues1)
                .WithOne(e => e.Milestone1)
                .HasForeignKey(e => e.AffectedMilestoneId);

            builder.Entity<Priority>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Priority)
                .HasForeignKey(e => e.PriorityId);

            builder.Entity<Resolution>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Resolution)
                .HasForeignKey(e => e.ResolutionId);

            builder.Entity<Project>()
                .HasOne(e => e.DefaultValues)
                .WithOne(e => e.Projects)
                .OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Cascade);

            builder.Entity<Project>()
             .HasMany(e => e.Issues)
             .WithOne(e => e.Project)
             .HasForeignKey(e => e.ProjectId)
             .OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Cascade);

            //builder.Entity<Project>()
            //    .HasMany(e => e.Roles)
            //    .WithOne(e => e.Project)
            //    .OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Cascade);

            builder.Entity<ProjectStatus>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Status)
                .HasForeignKey(e => e.StatusId);

            builder.Entity<RelatedIssue>()
                .HasKey(e => new { e.PrimaryIssueId, e.SecondaryIssueId, e.RelationType });

            builder.Entity<UserProject>()
               .HasKey(e => new { e.UserId, e.ProjectId });

            //builder.Entity<Project>()
            //   .HasOne(e => e.CreatedUser)
            //   .WithMany(e => e.Projects)
            //   .HasForeignKey(e => e.ProjectCreatorUserId)
            //   .HasConstraintName("FK_BugNet_Projects_Users");

            //builder.Entity<Project>()
            //   .HasOne(e => e.Manager)
            //   .WithMany(e => e.ManagedProjects)
            //   .HasForeignKey(e => e.ProjectManagerUserId)
            //   .HasConstraintName("FK_BugNet_Projects_Users1");
        }
    }
}
