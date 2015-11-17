using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace BugNET.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //protected override void OnModelCreating(builder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}

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
        public virtual DbSet<RolePermission> Permissions { get; set; }
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
        //public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }

        //public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<ApplicationLog>()
            //    .Property(e => e.Thread)
            //    .IsUnicode(false);

            //builder.Entity<ApplicationLog>()
            //    .Property(e => e.Level)
            //    .IsUnicode(false);

            //builder.Entity<ApplicationLog>()
            //    .Property(e => e.Logger)
            //    .IsUnicode(false);

            //builder.Entity<ApplicationLog>()
            //    .Property(e => e.Message)
            //    .IsUnicode(false);

            //builder.Entity<ApplicationLog>()
            //    .Property(e => e.Exception)
            //    .IsUnicode(false);

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
                .ForeignKey(e => e.IssueId)
                .WillCascadeOnDelete(false);

            //builder.Entity<RandomThing>().HasOne(e => e.Bag).WithMany(p => p.RandomThings).ForeignKey(e => e.BagId);
            builder.Entity<Issue>()
                .HasMany(e => e.RelatedIssues)
                .WithOne(e => e.PrimaryIssue)
                .ForeignKey(e => e.PrimaryIssueId);

            builder.Entity<Issue>()
                .HasMany(e => e.RelatedIssues1)
                .WithOne(e => e.SecondaryIssue)
                .ForeignKey(e => e.SecondaryIssueId)
                .WillCascadeOnDelete(false);

            builder.Entity<IssueWorkReport>()
                .Property(e => e.Duration)
                //.HasPrecision(4, 2);
                .HasColumnType("decimal(4,2)");

            //builder.Entity<RolePermission>()
            //    .HasMany(e => e.Roles)
            //    .WithMany(e => e.Permissions)
            //    .Map(m => m.ToTable("RolePermissions").MapLeftKey("PermissionId").MapRightKey("RoleId"));

            builder.Entity<Category>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Category)
                .ForeignKey(e => e.CategoryId);

            builder.Entity<CustomField>()
                .HasMany(e => e.ProjectCustomFieldValues)
                .WithOne(e => e.ProjectCustomFields)
                .WillCascadeOnDelete(false);

            builder.Entity<Milestone>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Milestone)
                .ForeignKey(e => e.ilestoneId);

            builder.Entity<Milestone>()
                .HasMany(e => e.Issues1)
                .WithOne(e => e.Milestone1)
                .ForeignKey(e => e.AffectedMilestoneId);

            builder.Entity<Priority>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Priority)
                .ForeignKey(e => e.PriorityId);

            builder.Entity<Resolution>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Resolution)
                .ForeignKey(e => e.ResolutionId);

            builder.Entity<Project>()
                .HasOne(e => e.DefaultValues)
                .WithOne(e => e.Projects)
                .WillCascadeOnDelete();

            builder.Entity<Project>()
                .HasMany(e => e.Roles)
                .WithOne(e => e.Project)
                .WillCascadeOnDelete();

            builder.Entity<ProjectStatus>()
                .HasMany(e => e.Issues)
                .WithOne(e => e.Status)
                .ForeignKey(e => e.StatusId);
        }
    }
}
