using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace BugNET.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BugNet_DefaultValues>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).ValueGeneratedNever();

                entity.Property(e => e.AssignedToNotify).HasDefaultValue(true);

                entity.Property(e => e.IssueEstimation).HasColumnType("decimal");

                entity.Property(e => e.OwnedByNotify).HasDefaultValue(true);

                entity.HasOne(d => d.IssueAssignedUser).WithMany(p => p.BugNet_DefaultValues).HasForeignKey(d => d.IssueAssignedUserId);

                entity.HasOne(d => d.IssueOwnerUser).WithMany(p => p.BugNet_DefaultValuesNavigation).HasForeignKey(d => d.IssueOwnerUserId).OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Project).WithOne(p => p.BugNet_DefaultValues).HasForeignKey<BugNet_DefaultValues>(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_DefaultValuesVisibility>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).ValueGeneratedNever();

                entity.Property(e => e.AffectedMilestoneEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.AffectedMilestoneVisibility).HasDefaultValue(true);

                entity.Property(e => e.AssignedToEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.AssignedToVisibility).HasDefaultValue(true);

                entity.Property(e => e.CategoryEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.CategoryVisibility).HasDefaultValue(true);

                entity.Property(e => e.DueDateEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.DueDateVisibility).HasDefaultValue(true);

                entity.Property(e => e.EstimationEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.EstimationVisibility).HasDefaultValue(true);

                entity.Property(e => e.MilestoneEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.MilestoneVisibility).HasDefaultValue(true);

                entity.Property(e => e.OwnedByEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.OwnedByVisibility).HasDefaultValue(true);

                entity.Property(e => e.PercentCompleteEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.PercentCompleteVisibility).HasDefaultValue(true);

                entity.Property(e => e.PriorityEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.PriorityVisibility).HasDefaultValue(true);

                entity.Property(e => e.PrivateEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.PrivateVisibility).HasDefaultValue(true);

                entity.Property(e => e.ResolutionEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.ResolutionVisibility).HasDefaultValue(true);

                entity.Property(e => e.StatusEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.StatusVisibility).HasDefaultValue(true);

                entity.Property(e => e.TypeEditVisibility).HasDefaultValue(true);

                entity.Property(e => e.TypeVisibility).HasDefaultValue(true);
            });

            modelBuilder.Entity<BugNet_HostSettings>(entity =>
            {
                entity.HasKey(e => e.SettingName);

                entity.Property(e => e.SettingName).HasMaxLength(50);
            });

            modelBuilder.Entity<BugNet_IssueAttachments>(entity =>
            {
                entity.HasKey(e => e.IssueAttachmentId);

                entity.HasIndex(e => new { e.IssueAttachmentId, e.FileName, e.Description, e.FileSize, e.ContentType, e.UserId, e.Attachment, e.DateCreated, e.IssueId }).HasName("IX_BugNet_IssueAttachments_DateCreated_IssueId");

                entity.Property(e => e.Attachment).HasColumnType("varbinary");

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Issue).WithMany(p => p.BugNet_IssueAttachments).HasForeignKey(d => d.IssueId);

                entity.HasOne(d => d.User).WithMany(p => p.BugNet_IssueAttachments).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BugNet_IssueComments>(entity =>
            {
                entity.HasKey(e => e.IssueCommentId);

                entity.HasIndex(e => new { e.IssueCommentId, e.Comment, e.IssueId, e.UserId, e.DateCreated }).HasName("IX_BugNet_IssueComments_IssueId_UserId_DateCreated");

                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.Issue).WithMany(p => p.BugNet_IssueComments).HasForeignKey(d => d.IssueId);

                entity.HasOne(d => d.User).WithMany(p => p.BugNet_IssueComments).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BugNet_IssueHistory>(entity =>
            {
                entity.HasKey(e => e.IssueHistoryId);

                entity.HasIndex(e => new { e.IssueHistoryId, e.FieldChanged, e.OldValue, e.NewValue, e.IssueId, e.UserId, e.DateCreated }).HasName("IX_BugNet_IssueHistory_IssueId_UserId_DateCreated");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.FieldChanged)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NewValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OldValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Issue).WithMany(p => p.BugNet_IssueHistory).HasForeignKey(d => d.IssueId);

                entity.HasOne(d => d.User).WithMany(p => p.BugNet_IssueHistory).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BugNet_IssueNotifications>(entity =>
            {
                entity.HasKey(e => e.IssueNotificationId);

                entity.HasOne(d => d.Issue).WithMany(p => p.BugNet_IssueNotifications).HasForeignKey(d => d.IssueId);

                entity.HasOne(d => d.User).WithMany(p => p.BugNet_IssueNotifications).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BugNet_IssueRevisions>(entity =>
            {
                entity.HasKey(e => e.IssueRevisionId);

                entity.Property(e => e.Branch).HasMaxLength(255);

                entity.Property(e => e.Changeset).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Repository)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.RevisionAuthor)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RevisionDate)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RevisionMessage).IsRequired();

                entity.HasOne(d => d.Issue).WithMany(p => p.BugNet_IssueRevisions).HasForeignKey(d => d.IssueId);
            });

            modelBuilder.Entity<BugNet_IssueVotes>(entity =>
            {
                entity.HasKey(e => e.IssueVoteId);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Issue).WithMany(p => p.BugNet_IssueVotes).HasForeignKey(d => d.IssueId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User).WithMany(p => p.BugNet_IssueVotes).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BugNet_IssueWorkReports>(entity =>
            {
                entity.HasKey(e => e.IssueWorkReportId);

                entity.Property(e => e.Duration).HasColumnType("decimal");

                entity.Property(e => e.WorkDate).HasColumnType("datetime");

                entity.HasOne(d => d.Issue).WithMany(p => p.BugNet_IssueWorkReports).HasForeignKey(d => d.IssueId);

                entity.HasOne(d => d.User).WithMany(p => p.BugNet_IssueWorkReports).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BugNet_Issues>(entity =>
            {
                entity.HasKey(e => e.IssueId);

                entity.HasIndex(e => new { e.IssueCategoryId, e.ProjectId, e.Disabled, e.IssueStatusId }).HasName("IX_BugNet_Issues_IssueCategoryId_ProjectId_Disabled_IssueStatusId");

                entity.HasIndex(e => new { e.IssueStatusId, e.IssueId, e.ProjectId, e.Disabled }).HasName("IX_BugNet_Issues_IssueId_ProjectId_Disabled");

                entity.HasIndex(e => new { e.IssueTitle, e.IssueDescription, e.IssueDueDate, e.IssueVisibility, e.IssueEstimation, e.IssueProgress, e.DateCreated, e.LastUpdate, e.IssueAssignedUserId, e.Disabled, e.IssueId, e.IssueMilestoneId, e.IssueAffectedMilestoneId, e.ProjectId, e.IssueTypeId, e.IssuePriorityId, e.IssueCategoryId, e.IssueStatusId, e.IssueResolutionId, e.LastUpdateUserId, e.IssueCreatorUserId, e.IssueOwnerUserId }).HasName("IX_BugNet_Issues_K12_K22_K1_K15_K9_K8_K6_K5_K7_K4_K10_K21_K11_K13_2_3_14_16_17_18_19_20");

                entity.HasIndex(e => new { e.IssueTitle, e.IssueDescription, e.IssueDueDate, e.IssueVisibility, e.IssueEstimation, e.IssueProgress, e.DateCreated, e.LastUpdate, e.ProjectId, e.Disabled, e.IssueId, e.IssueOwnerUserId, e.IssueCreatorUserId, e.LastUpdateUserId, e.IssueAssignedUserId, e.IssueResolutionId, e.IssueMilestoneId, e.IssueAffectedMilestoneId, e.IssueStatusId, e.IssueCategoryId, e.IssuePriorityId, e.IssueTypeId }).HasName("IX_BugNet_Issues_K8_K22_K1_K13_K11_K21_K12_K10_K15_K9_K4_K7_K5_K6_2_3_14_16_17_18_19_20");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Disabled).HasDefaultValue(false);

                entity.Property(e => e.IssueDescription).IsRequired();

                entity.Property(e => e.IssueDueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'1/1/1900 12:00:00 AM'");

                entity.Property(e => e.IssueEstimation)
                    .HasColumnType("decimal")
                    .HasDefaultValue(0m);

                entity.Property(e => e.IssueProgress).HasDefaultValue(0);

                entity.Property(e => e.IssueTitle)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.HasOne(d => d.IssueAffectedMilestone).WithMany(p => p.BugNet_Issues).HasForeignKey(d => d.IssueAffectedMilestoneId);

                entity.HasOne(d => d.IssueAssignedUser).WithMany(p => p.BugNet_Issues).HasForeignKey(d => d.IssueAssignedUserId);

                entity.HasOne(d => d.IssueCategory).WithMany(p => p.BugNet_Issues).HasForeignKey(d => d.IssueCategoryId);

                entity.HasOne(d => d.IssueCreatorUser).WithMany(p => p.BugNet_IssuesNavigation).HasForeignKey(d => d.IssueCreatorUserId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.IssueMilestone).WithMany(p => p.BugNet_IssuesNavigation).HasForeignKey(d => d.IssueMilestoneId);

                entity.HasOne(d => d.IssueOwnerUser).WithMany(p => p.BugNet_Issues1).HasForeignKey(d => d.IssueOwnerUserId);

                entity.HasOne(d => d.IssuePriority).WithMany(p => p.BugNet_Issues).HasForeignKey(d => d.IssuePriorityId);

                entity.HasOne(d => d.IssueResolution).WithMany(p => p.BugNet_Issues).HasForeignKey(d => d.IssueResolutionId);

                entity.HasOne(d => d.IssueStatus).WithMany(p => p.BugNet_Issues).HasForeignKey(d => d.IssueStatusId);

                entity.HasOne(d => d.IssueType).WithMany(p => p.BugNet_Issues).HasForeignKey(d => d.IssueTypeId);

                entity.HasOne(d => d.LastUpdateUser).WithMany(p => p.BugNet_Issues2).HasForeignKey(d => d.LastUpdateUserId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_Issues).HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_Languages>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CultureName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FallbackCulture).HasMaxLength(50);
            });

            modelBuilder.Entity<BugNet_Permissions>(entity =>
            {
                entity.HasKey(e => e.PermissionId);

                entity.Property(e => e.PermissionId).ValueGeneratedNever();

                entity.Property(e => e.PermissionKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PermissionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BugNet_ProjectCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Disabled).HasDefaultValue(false);

                entity.Property(e => e.ParentCategoryId).HasDefaultValue(0);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_ProjectCategories).HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_ProjectCustomFieldSelections>(entity =>
            {
                entity.HasKey(e => e.CustomFieldSelectionId);

                entity.Property(e => e.CustomFieldSelectionName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CustomFieldSelectionSortOrder).HasDefaultValue(0);

                entity.Property(e => e.CustomFieldSelectionValue)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.CustomField).WithMany(p => p.BugNet_ProjectCustomFieldSelections).HasForeignKey(d => d.CustomFieldId);
            });

            modelBuilder.Entity<BugNet_ProjectCustomFieldTypes>(entity =>
            {
                entity.HasKey(e => e.CustomFieldTypeId);

                entity.Property(e => e.CustomFieldTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BugNet_ProjectCustomFieldValues>(entity =>
            {
                entity.HasKey(e => e.CustomFieldValueId);

                entity.HasOne(d => d.CustomField).WithMany(p => p.BugNet_ProjectCustomFieldValues).HasForeignKey(d => d.CustomFieldId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Issue).WithMany(p => p.BugNet_ProjectCustomFieldValues).HasForeignKey(d => d.IssueId);
            });

            modelBuilder.Entity<BugNet_ProjectCustomFields>(entity =>
            {
                entity.HasKey(e => e.CustomFieldId);

                entity.Property(e => e.CustomFieldName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CustomFieldType).WithMany(p => p.BugNet_ProjectCustomFields).HasForeignKey(d => d.CustomFieldTypeId);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_ProjectCustomFields).HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_ProjectIssueTypes>(entity =>
            {
                entity.HasKey(e => e.IssueTypeId);

                entity.Property(e => e.IssueTypeImageUrl)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IssueTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_ProjectIssueTypes).HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_ProjectMailBoxes>(entity =>
            {
                entity.HasKey(e => e.ProjectMailboxId);

                entity.Property(e => e.MailBox)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.AssignToUser).WithMany(p => p.BugNet_ProjectMailBoxes).HasForeignKey(d => d.AssignToUserId);

                entity.HasOne(d => d.Category).WithMany(p => p.BugNet_ProjectMailBoxes).HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.IssueType).WithMany(p => p.BugNet_ProjectMailBoxes).HasForeignKey(d => d.IssueTypeId);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_ProjectMailBoxes).HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_ProjectMilestones>(entity =>
            {
                entity.HasKey(e => e.MilestoneId);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.MilestoneCompleted).HasDefaultValue(false);

                entity.Property(e => e.MilestoneDueDate).HasColumnType("datetime");

                entity.Property(e => e.MilestoneImageUrl)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MilestoneName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MilestoneReleaseDate).HasColumnType("datetime");

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_ProjectMilestones).HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_ProjectNotifications>(entity =>
            {
                entity.HasKey(e => e.ProjectNotificationId);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_ProjectNotifications).HasForeignKey(d => d.ProjectId);

                entity.HasOne(d => d.User).WithMany(p => p.BugNet_ProjectNotifications).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BugNet_ProjectPriorities>(entity =>
            {
                entity.HasKey(e => e.PriorityId);

                entity.Property(e => e.PriorityImageUrl)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PriorityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_ProjectPriorities).HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_ProjectResolutions>(entity =>
            {
                entity.HasKey(e => e.ResolutionId);

                entity.Property(e => e.ResolutionImageUrl)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResolutionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_ProjectResolutions).HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_ProjectStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.StatusImageUrl)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_ProjectStatus).HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<BugNet_Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.AllowAttachments).HasDefaultValue(true);

                entity.Property(e => e.AllowIssueVoting).HasDefaultValue(true);

                entity.Property(e => e.AttachmentUploadPath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProjectDescription).IsRequired();

                entity.Property(e => e.ProjectDisabled).HasDefaultValue(false);

                entity.Property(e => e.ProjectImageContentType).HasMaxLength(50);

                entity.Property(e => e.ProjectImageFileContent).HasColumnType("varbinary");

                entity.Property(e => e.ProjectImageFileName).HasMaxLength(150);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SvnRepositoryUrl).HasMaxLength(255);

                entity.HasOne(d => d.ProjectCreatorUser).WithMany(p => p.BugNet_Projects).HasForeignKey(d => d.ProjectCreatorUserId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ProjectManagerUser).WithMany(p => p.BugNet_ProjectsNavigation).HasForeignKey(d => d.ProjectManagerUserId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BugNet_Queries>(entity =>
            {
                entity.HasKey(e => e.QueryId);

                entity.Property(e => e.IsPublic).HasDefaultValue(false);

                entity.Property(e => e.QueryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_Queries).HasForeignKey(d => d.ProjectId);

                entity.HasOne(d => d.User).WithMany(p => p.BugNet_Queries).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BugNet_QueryClauses>(entity =>
            {
                entity.HasKey(e => e.QueryClauseId);

                entity.Property(e => e.BooleanOperator)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ComparisonOperator)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FieldValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Query).WithMany(p => p.BugNet_QueryClauses).HasForeignKey(d => d.QueryId);
            });

            modelBuilder.Entity<BugNet_RelatedIssues>(entity =>
            {
                entity.HasKey(e => new { e.PrimaryIssueId, e.SecondaryIssueId, e.RelationType });

                entity.HasOne(d => d.PrimaryIssue).WithMany(p => p.BugNet_RelatedIssues).HasForeignKey(d => d.PrimaryIssueId);

                entity.HasOne(d => d.SecondaryIssue).WithMany(p => p.BugNet_RelatedIssuesNavigation).HasForeignKey(d => d.SecondaryIssueId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BugNet_RequiredFieldList>(entity =>
            {
                entity.HasKey(e => e.RequiredFieldId);

                entity.Property(e => e.RequiredFieldId).ValueGeneratedNever();

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FieldValue)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BugNet_RolePermissions>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId });

                entity.HasOne(d => d.Permission).WithMany(p => p.BugNet_RolePermissions).HasForeignKey(d => d.PermissionId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Role).WithMany(p => p.BugNet_RolePermissions).HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<BugNet_Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_Roles).HasForeignKey(d => d.ProjectId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BugNet_UserProjects>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjectId });

                entity.HasOne(d => d.Project).WithMany(p => p.BugNet_UserProjects).HasForeignKey(d => d.ProjectId);

                entity.HasOne(d => d.User).WithMany(p => p.BugNet_UserProjects).HasForeignKey(d => d.UserId);
            });
        }

        public virtual DbSet<BugNet_DefaultValues> BugNet_DefaultValues { get; set; }
        public virtual DbSet<BugNet_DefaultValuesVisibility> BugNet_DefaultValuesVisibility { get; set; }
        public virtual DbSet<BugNet_HostSettings> BugNet_HostSettings { get; set; }
        public virtual DbSet<BugNet_IssueAttachments> BugNet_IssueAttachments { get; set; }
        public virtual DbSet<BugNet_IssueComments> BugNet_IssueComments { get; set; }
        public virtual DbSet<BugNet_IssueHistory> BugNet_IssueHistory { get; set; }
        public virtual DbSet<BugNet_IssueNotifications> BugNet_IssueNotifications { get; set; }
        public virtual DbSet<BugNet_IssueRevisions> BugNet_IssueRevisions { get; set; }
        public virtual DbSet<BugNet_IssueVotes> BugNet_IssueVotes { get; set; }
        public virtual DbSet<BugNet_IssueWorkReports> BugNet_IssueWorkReports { get; set; }
        public virtual DbSet<BugNet_Issues> BugNet_Issues { get; set; }
        public virtual DbSet<BugNet_Languages> BugNet_Languages { get; set; }
        public virtual DbSet<BugNet_Permissions> BugNet_Permissions { get; set; }
        public virtual DbSet<BugNet_ProjectCategories> BugNet_ProjectCategories { get; set; }
        public virtual DbSet<BugNet_ProjectCustomFieldSelections> BugNet_ProjectCustomFieldSelections { get; set; }
        public virtual DbSet<BugNet_ProjectCustomFieldTypes> BugNet_ProjectCustomFieldTypes { get; set; }
        public virtual DbSet<BugNet_ProjectCustomFieldValues> BugNet_ProjectCustomFieldValues { get; set; }
        public virtual DbSet<BugNet_ProjectCustomFields> BugNet_ProjectCustomFields { get; set; }
        public virtual DbSet<BugNet_ProjectIssueTypes> BugNet_ProjectIssueTypes { get; set; }
        public virtual DbSet<BugNet_ProjectMailBoxes> BugNet_ProjectMailBoxes { get; set; }
        public virtual DbSet<BugNet_ProjectMilestones> BugNet_ProjectMilestones { get; set; }
        public virtual DbSet<BugNet_ProjectNotifications> BugNet_ProjectNotifications { get; set; }
        public virtual DbSet<BugNet_ProjectPriorities> BugNet_ProjectPriorities { get; set; }
        public virtual DbSet<BugNet_ProjectResolutions> BugNet_ProjectResolutions { get; set; }
        public virtual DbSet<BugNet_ProjectStatus> BugNet_ProjectStatus { get; set; }
        public virtual DbSet<BugNet_Projects> BugNet_Projects { get; set; }
        public virtual DbSet<BugNet_Queries> BugNet_Queries { get; set; }
        public virtual DbSet<BugNet_QueryClauses> BugNet_QueryClauses { get; set; }
        public virtual DbSet<BugNet_RelatedIssues> BugNet_RelatedIssues { get; set; }
        public virtual DbSet<BugNet_RequiredFieldList> BugNet_RequiredFieldList { get; set; }
        public virtual DbSet<BugNet_RolePermissions> BugNet_RolePermissions { get; set; }
        public virtual DbSet<BugNet_Roles> BugNet_Roles { get; set; }
        public virtual DbSet<BugNet_UserProjects> BugNet_UserProjects { get; set; }
    }
}
