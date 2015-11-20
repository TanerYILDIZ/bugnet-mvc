using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BugNET.Models;

namespace BugNET.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20151119155733_CreateBugNETSchema")]
    partial class CreateBugNETSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BugNET.Models.ApplicationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Exception")
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Logger")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 4000);

                    b.Property<string>("Thread")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("User")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "BugNet_ApplicationLog");
                });

            modelBuilder.Entity("BugNET.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "ApplicationUser");
                });

            modelBuilder.Entity("BugNET.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<bool>("Disabled");

                    b.Property<int>("ParentCategoryId");

                    b.Property<int>("ProjectId");

                    b.HasKey("CategoryId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectCategories");
                });

            modelBuilder.Entity("BugNET.Models.CustomField", b =>
                {
                    b.Property<int>("CustomFieldId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomFieldDataType");

                    b.Property<string>("CustomFieldName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool>("CustomFieldRequired");

                    b.Property<int>("CustomFieldTypeId");

                    b.Property<int>("ProjectId");

                    b.HasKey("CustomFieldId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectCustomFields");
                });

            modelBuilder.Entity("BugNET.Models.CustomFieldSelection", b =>
                {
                    b.Property<int>("CustomFieldSelectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomFieldId");

                    b.Property<string>("CustomFieldSelectionName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("CustomFieldSelectionSortOrder");

                    b.Property<string>("CustomFieldSelectionValue")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("CustomFieldSelectionId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectCustomFieldSelections");
                });

            modelBuilder.Entity("BugNET.Models.CustomFieldType", b =>
                {
                    b.Property<int>("CustomFieldTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomFieldTypeName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("CustomFieldTypeId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectCustomFieldTypes");
                });

            modelBuilder.Entity("BugNET.Models.CustomFieldValue", b =>
                {
                    b.Property<int>("CustomFieldValueId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomFieldId");

                    b.Property<int>("IssueId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "CustomFieldValue");

                    b.HasKey("CustomFieldValueId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectCustomFieldValues");
                });

            modelBuilder.Entity("BugNET.Models.DefaultValues", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<bool?>("AssignedToNotify");

                    b.Property<int?>("DefaultType");

                    b.Property<int?>("IssueAffectedMilestoneId");

                    b.Property<Guid?>("IssueAssignedUserId");

                    b.Property<int?>("IssueCategoryId");

                    b.Property<int?>("IssueDueDate");

                    b.Property<decimal?>("IssueEstimation")
                        .HasAnnotation("Relational:ColumnType", "decimal(5,2)");

                    b.Property<int?>("IssueMilestoneId");

                    b.Property<Guid?>("IssueOwnerUserId");

                    b.Property<int?>("IssuePriorityId");

                    b.Property<int?>("IssueProgress");

                    b.Property<int?>("IssueResolutionId");

                    b.Property<int?>("IssueVisibility");

                    b.Property<bool?>("OwnedByNotify");

                    b.Property<int?>("StatusId");

                    b.HasKey("ProjectId");

                    b.HasAnnotation("Relational:TableName", "BugNet_DefaultValues");
                });

            modelBuilder.Entity("BugNET.Models.DefaultValuesVisibility", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<bool>("AffectedMilestoneEditVisibility");

                    b.Property<bool>("AffectedMilestoneVisibility");

                    b.Property<bool>("AssignedToEditVisibility");

                    b.Property<bool>("AssignedToVisibility");

                    b.Property<bool>("CategoryEditVisibility");

                    b.Property<bool>("CategoryVisibility");

                    b.Property<bool>("DueDateEditVisibility");

                    b.Property<bool>("DueDateVisibility");

                    b.Property<bool>("EstimationEditVisibility");

                    b.Property<bool>("EstimationVisibility");

                    b.Property<bool>("MilestoneEditVisibility");

                    b.Property<bool>("MilestoneVisibility");

                    b.Property<bool>("OwnedByEditVisibility");

                    b.Property<bool>("OwnedByVisibility");

                    b.Property<bool>("PercentCompleteEditVisibility");

                    b.Property<bool>("PercentCompleteVisibility");

                    b.Property<bool>("PriorityEditVisibility");

                    b.Property<bool>("PriorityVisibility");

                    b.Property<bool>("PrivateEditVisibility");

                    b.Property<bool>("PrivateVisibility");

                    b.Property<bool>("ResolutionEditVisibility");

                    b.Property<bool>("ResolutionVisibility");

                    b.Property<bool>("StatusEditVisibility");

                    b.Property<bool>("StatusVisibility");

                    b.Property<bool>("TypeEditVisibility");

                    b.Property<bool>("TypeVisibility");

                    b.HasKey("ProjectId");

                    b.HasAnnotation("Relational:TableName", "BugNet_DefaultValuesVisibility");
                });

            modelBuilder.Entity("BugNET.Models.HostSetting", b =>
                {
                    b.Property<string>("SettingName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("SettingValue");

                    b.HasKey("SettingName");

                    b.HasAnnotation("Relational:TableName", "BugNet_HostSettings");
                });

            modelBuilder.Entity("BugNET.Models.Issue", b =>
                {
                    b.Property<int>("IssueId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AffectedMilestoneId")
                        .HasAnnotation("Relational:ColumnName", "IssueAffectedMilestoneId");

                    b.Property<Guid?>("AssignedUserId")
                        .HasAnnotation("Relational:ColumnName", "IssueAssignedUserId");

                    b.Property<int?>("CategoryId")
                        .HasAnnotation("Relational:ColumnName", "IssueCategoryId");

                    b.Property<Guid>("CreatorUserId")
                        .HasAnnotation("Relational:ColumnName", "IssueCreatorUserId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "IssueDescription");

                    b.Property<bool>("Disabled");

                    b.Property<DateTime?>("DueDate")
                        .HasAnnotation("Relational:ColumnName", "IssueDueDate");

                    b.Property<decimal>("Estimation")
                        .HasAnnotation("Relational:ColumnName", "IssueEstimation")
                        .HasAnnotation("Relational:ColumnType", "decimal(5,2)");

                    b.Property<string>("IssueTitle")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.Property<int?>("IssueTypeIssueTypeId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<Guid>("LastUpdateUserId");

                    b.Property<Guid?>("OwnerUserId")
                        .HasAnnotation("Relational:ColumnName", "IssueOwnerUserId");

                    b.Property<int?>("PriorityId")
                        .HasAnnotation("Relational:ColumnName", "IssuePriorityId");

                    b.Property<int>("Progress")
                        .HasAnnotation("Relational:ColumnName", "IssueProgress");

                    b.Property<int>("ProjectId");

                    b.Property<int?>("ResolutionId")
                        .HasAnnotation("Relational:ColumnName", "IssueResolutionId");

                    b.Property<int?>("StatusId")
                        .HasAnnotation("Relational:ColumnName", "IssueStatusId");

                    b.Property<int?>("TypeId")
                        .HasAnnotation("Relational:ColumnName", "IssueTypeId");

                    b.Property<int>("Visibility")
                        .HasAnnotation("Relational:ColumnName", "IssueVisibility");

                    b.Property<int?>("ilestoneId")
                        .HasAnnotation("Relational:ColumnName", "IssueMilestoneId");

                    b.HasKey("IssueId");

                    b.HasAnnotation("Relational:TableName", "BugNet_Issues");
                });

            modelBuilder.Entity("BugNET.Models.IssueAttachment", b =>
                {
                    b.Property<int>("IssueAttachmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Attachment");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 250);

                    b.Property<int>("FileSize");

                    b.Property<int>("IssueId");

                    b.Property<Guid>("UserId");

                    b.HasKey("IssueAttachmentId");

                    b.HasAnnotation("Relational:TableName", "BugNet_IssueAttachments");
                });

            modelBuilder.Entity("BugNET.Models.IssueComment", b =>
                {
                    b.Property<int>("IssueCommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("IssueId");

                    b.Property<Guid>("UserId");

                    b.HasKey("IssueCommentId");

                    b.HasAnnotation("Relational:TableName", "BugNet_IssueComments");
                });

            modelBuilder.Entity("BugNET.Models.IssueHistory", b =>
                {
                    b.Property<int>("IssueHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("FieldChanged")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("IssueId");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("OldValue")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UserId");

                    b.HasKey("IssueHistoryId");

                    b.HasAnnotation("Relational:TableName", "BugNet_IssueHistory");
                });

            modelBuilder.Entity("BugNET.Models.IssueNotification", b =>
                {
                    b.Property<int>("IssueNotificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IssueId");

                    b.Property<Guid>("UserId");

                    b.HasKey("IssueNotificationId");

                    b.HasAnnotation("Relational:TableName", "BugNet_IssueNotifications");
                });

            modelBuilder.Entity("BugNET.Models.IssueRevision", b =>
                {
                    b.Property<int>("IssueRevisionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Branch")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Changeset")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("IssueId");

                    b.Property<string>("Repository")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 400);

                    b.Property<int>("Revision");

                    b.Property<string>("RevisionAuthor")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("RevisionDate")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("RevisionMessage")
                        .IsRequired();

                    b.HasKey("IssueRevisionId");

                    b.HasAnnotation("Relational:TableName", "BugNet_IssueRevisions");
                });

            modelBuilder.Entity("BugNET.Models.IssueType", b =>
                {
                    b.Property<int>("IssueTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IssueTypeImageUrl")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("IssueTypeName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("ProjectId");

                    b.Property<int>("SortOrder");

                    b.HasKey("IssueTypeId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectIssueTypes");
                });

            modelBuilder.Entity("BugNET.Models.IssueVote", b =>
                {
                    b.Property<int>("IssueVoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("IssueId");

                    b.Property<Guid>("UserId");

                    b.HasKey("IssueVoteId");

                    b.HasAnnotation("Relational:TableName", "BugNet_IssueVotes");
                });

            modelBuilder.Entity("BugNET.Models.IssueWorkReport", b =>
                {
                    b.Property<int>("IssueWorkReportId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Duration")
                        .HasAnnotation("Relational:ColumnType", "decimal(4,2)");

                    b.Property<int>("IssueCommentId");

                    b.Property<int>("IssueId");

                    b.Property<Guid>("UserId");

                    b.Property<DateTime>("WorkDate");

                    b.HasKey("IssueWorkReportId");

                    b.HasAnnotation("Relational:TableName", "BugNet_IssueWorkReports");
                });

            modelBuilder.Entity("BugNET.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CultureCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("CultureName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("FallbackCulture")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("LanguageId");

                    b.HasAnnotation("Relational:TableName", "BugNet_Languages");
                });

            modelBuilder.Entity("BugNET.Models.Milestone", b =>
                {
                    b.Property<int>("MilestoneId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("MilestoneCompleted");

                    b.Property<DateTime?>("MilestoneDueDate");

                    b.Property<string>("MilestoneImageUrl")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("MilestoneName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("MilestoneNotes");

                    b.Property<DateTime?>("MilestoneReleaseDate");

                    b.Property<int>("ProjectId");

                    b.Property<int>("SortOrder");

                    b.HasKey("MilestoneId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectMilestones");
                });

            modelBuilder.Entity("BugNET.Models.Priority", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PriorityImageUrl")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("PriorityName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("ProjectId");

                    b.Property<int>("SortOrder");

                    b.HasKey("PriorityId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectPriorities");
                });

            modelBuilder.Entity("BugNET.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowAttachments");

                    b.Property<bool>("AllowIssueVoting");

                    b.Property<string>("AttachmentUploadPath")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("ProjectAccessType");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("ProjectCreatorUserId");

                    b.Property<string>("ProjectDescription")
                        .IsRequired();

                    b.Property<bool>("ProjectDisabled");

                    b.Property<string>("ProjectImageContentType")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<byte[]>("ProjectImageFileContent");

                    b.Property<string>("ProjectImageFileName")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<long?>("ProjectImageFileSize");

                    b.Property<Guid>("ProjectManagerUserId");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("SvnRepositoryUrl")
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("ProjectId");

                    b.HasAnnotation("Relational:TableName", "BugNet_Projects");
                });

            modelBuilder.Entity("BugNET.Models.ProjectMailbox", b =>
                {
                    b.Property<int>("ProjectMailboxId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AssignToUserId");

                    b.Property<int?>("IssueTypeId");

                    b.Property<string>("MailBox")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("ProjectId");

                    b.HasKey("ProjectMailboxId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectMailBoxes");
                });

            modelBuilder.Entity("BugNET.Models.ProjectNotification", b =>
                {
                    b.Property<int>("ProjectNotificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<Guid>("UserId");

                    b.HasKey("ProjectNotificationId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectNotifications");
                });

            modelBuilder.Entity("BugNET.Models.ProjectStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsClosedState");

                    b.Property<int>("ProjectId");

                    b.Property<int>("SortOrder");

                    b.Property<string>("StatusImageUrl")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("StatusId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectStatus");
                });

            modelBuilder.Entity("BugNET.Models.Query", b =>
                {
                    b.Property<int>("QueryId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsPublic");

                    b.Property<int>("ProjectId");

                    b.Property<string>("QueryName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<Guid>("UserId");

                    b.HasKey("QueryId");

                    b.HasAnnotation("Relational:TableName", "BugNet_Queries");
                });

            modelBuilder.Entity("BugNET.Models.QueryClause", b =>
                {
                    b.Property<int>("QueryClauseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BooleanOperator")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ComparisonOperator")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("CustomFieldId");

                    b.Property<int>("DataType");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("FieldValue")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("QueryId");

                    b.HasKey("QueryClauseId");

                    b.HasAnnotation("Relational:TableName", "BugNet_QueryClauses");
                });

            modelBuilder.Entity("BugNET.Models.RelatedIssue", b =>
                {
                    b.Property<int>("PrimaryIssueId");

                    b.Property<int>("SecondaryIssueId");

                    b.Property<int>("RelationType");

                    b.HasKey("PrimaryIssueId", "SecondaryIssueId", "RelationType");

                    b.HasAnnotation("Relational:TableName", "BugNet_RelatedIssues");
                });

            modelBuilder.Entity("BugNET.Models.RequiredField", b =>
                {
                    b.Property<int>("RequiredFieldId");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("FieldValue")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("RequiredFieldId");

                    b.HasAnnotation("Relational:TableName", "BugNet_RequiredFieldList");
                });

            modelBuilder.Entity("BugNET.Models.Resolution", b =>
                {
                    b.Property<int>("ResolutionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<string>("ResolutionImageUrl")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ResolutionName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("SortOrder");

                    b.HasKey("ResolutionId");

                    b.HasAnnotation("Relational:TableName", "BugNet_ProjectResolutions");
                });

            modelBuilder.Entity("BugNET.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AutoAssign");

                    b.Property<int?>("ProjectId");

                    b.Property<string>("RoleDescription")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("RoleId");

                    b.HasAnnotation("Relational:TableName", "BugNet_Roles");
                });

            modelBuilder.Entity("BugNET.Models.UserProject", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<int>("ProjectId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("SelectedIssueColumns")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("UserProjectId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("UserId", "ProjectId");

                    b.HasAnnotation("Relational:TableName", "BugNet_UserProjects");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("BugNET.Models.Category", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.CustomField", b =>
                {
                    b.HasOne("BugNET.Models.CustomFieldType")
                        .WithMany()
                        .HasForeignKey("CustomFieldTypeId");

                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.CustomFieldSelection", b =>
                {
                    b.HasOne("BugNET.Models.CustomField")
                        .WithMany()
                        .HasForeignKey("CustomFieldId");
                });

            modelBuilder.Entity("BugNET.Models.CustomFieldValue", b =>
                {
                    b.HasOne("BugNET.Models.CustomField")
                        .WithMany()
                        .HasForeignKey("CustomFieldId");

                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("BugNET.Models.DefaultValues", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithOne()
                        .HasForeignKey("BugNET.Models.DefaultValues", "ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.Issue", b =>
                {
                    b.HasOne("BugNET.Models.Milestone")
                        .WithMany()
                        .HasForeignKey("AffectedMilestoneId");

                    b.HasOne("BugNET.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("BugNET.Models.IssueType")
                        .WithMany()
                        .HasForeignKey("IssueTypeIssueTypeId");

                    b.HasOne("BugNET.Models.Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("BugNET.Models.Resolution")
                        .WithMany()
                        .HasForeignKey("ResolutionId");

                    b.HasOne("BugNET.Models.ProjectStatus")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("BugNET.Models.Milestone")
                        .WithMany()
                        .HasForeignKey("ilestoneId");
                });

            modelBuilder.Entity("BugNET.Models.IssueAttachment", b =>
                {
                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("BugNET.Models.IssueComment", b =>
                {
                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("BugNET.Models.IssueHistory", b =>
                {
                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("BugNET.Models.IssueNotification", b =>
                {
                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("BugNET.Models.IssueRevision", b =>
                {
                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("BugNET.Models.IssueType", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.IssueVote", b =>
                {
                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("BugNET.Models.IssueWorkReport", b =>
                {
                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("BugNET.Models.Milestone", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.Priority", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.ProjectMailbox", b =>
                {
                    b.HasOne("BugNET.Models.IssueType")
                        .WithMany()
                        .HasForeignKey("IssueTypeId");

                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.ProjectNotification", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.ProjectStatus", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.Query", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.QueryClause", b =>
                {
                    b.HasOne("BugNET.Models.Query")
                        .WithMany()
                        .HasForeignKey("QueryId");
                });

            modelBuilder.Entity("BugNET.Models.RelatedIssue", b =>
                {
                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("PrimaryIssueId");

                    b.HasOne("BugNET.Models.Issue")
                        .WithMany()
                        .HasForeignKey("SecondaryIssueId");
                });

            modelBuilder.Entity("BugNET.Models.Resolution", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.Role", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BugNET.Models.UserProject", b =>
                {
                    b.HasOne("BugNET.Models.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BugNET.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BugNET.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("BugNET.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
