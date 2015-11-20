using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace BugNET.Migrations
{
    public partial class CreateBugNETSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.CreateTable(
                name: "BugNet_ApplicationLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Exception = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: false),
                    Logger = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Thread = table.Column<string>(nullable: false),
                    User = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLog", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectCustomFieldTypes",
                columns: table => new
                {
                    CustomFieldTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFieldTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldType", x => x.CustomFieldTypeId);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_DefaultValuesVisibility",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    AffectedMilestoneEditVisibility = table.Column<bool>(nullable: false),
                    AffectedMilestoneVisibility = table.Column<bool>(nullable: false),
                    AssignedToEditVisibility = table.Column<bool>(nullable: false),
                    AssignedToVisibility = table.Column<bool>(nullable: false),
                    CategoryEditVisibility = table.Column<bool>(nullable: false),
                    CategoryVisibility = table.Column<bool>(nullable: false),
                    DueDateEditVisibility = table.Column<bool>(nullable: false),
                    DueDateVisibility = table.Column<bool>(nullable: false),
                    EstimationEditVisibility = table.Column<bool>(nullable: false),
                    EstimationVisibility = table.Column<bool>(nullable: false),
                    MilestoneEditVisibility = table.Column<bool>(nullable: false),
                    MilestoneVisibility = table.Column<bool>(nullable: false),
                    OwnedByEditVisibility = table.Column<bool>(nullable: false),
                    OwnedByVisibility = table.Column<bool>(nullable: false),
                    PercentCompleteEditVisibility = table.Column<bool>(nullable: false),
                    PercentCompleteVisibility = table.Column<bool>(nullable: false),
                    PriorityEditVisibility = table.Column<bool>(nullable: false),
                    PriorityVisibility = table.Column<bool>(nullable: false),
                    PrivateEditVisibility = table.Column<bool>(nullable: false),
                    PrivateVisibility = table.Column<bool>(nullable: false),
                    ResolutionEditVisibility = table.Column<bool>(nullable: false),
                    ResolutionVisibility = table.Column<bool>(nullable: false),
                    StatusEditVisibility = table.Column<bool>(nullable: false),
                    StatusVisibility = table.Column<bool>(nullable: false),
                    TypeEditVisibility = table.Column<bool>(nullable: false),
                    TypeVisibility = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultValuesVisibility", x => x.ProjectId);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_HostSettings",
                columns: table => new
                {
                    SettingName = table.Column<string>(nullable: false),
                    SettingValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostSetting", x => x.SettingName);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CultureCode = table.Column<string>(nullable: false),
                    CultureName = table.Column<string>(nullable: false),
                    FallbackCulture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowAttachments = table.Column<bool>(nullable: false),
                    AllowIssueVoting = table.Column<bool>(nullable: false),
                    AttachmentUploadPath = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ProjectAccessType = table.Column<int>(nullable: false),
                    ProjectCode = table.Column<string>(nullable: false),
                    ProjectCreatorUserId = table.Column<Guid>(nullable: false),
                    ProjectDescription = table.Column<string>(nullable: false),
                    ProjectDisabled = table.Column<bool>(nullable: false),
                    ProjectImageContentType = table.Column<string>(nullable: true),
                    ProjectImageFileContent = table.Column<byte[]>(nullable: true),
                    ProjectImageFileName = table.Column<string>(nullable: true),
                    ProjectImageFileSize = table.Column<long>(nullable: true),
                    ProjectManagerUserId = table.Column<Guid>(nullable: false),
                    ProjectName = table.Column<string>(nullable: false),
                    SvnRepositoryUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_RequiredFieldList",
                columns: table => new
                {
                    RequiredFieldId = table.Column<int>(nullable: false),
                    FieldName = table.Column<string>(nullable: false),
                    FieldValue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredField", x => x.RequiredFieldId);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    ParentCategoryId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectCustomFields",
                columns: table => new
                {
                    CustomFieldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFieldDataType = table.Column<int>(nullable: false),
                    CustomFieldName = table.Column<string>(nullable: false),
                    CustomFieldRequired = table.Column<bool>(nullable: false),
                    CustomFieldTypeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomField", x => x.CustomFieldId);
                    table.ForeignKey(
                        name: "FK_CustomField_CustomFieldType_CustomFieldTypeId",
                        column: x => x.CustomFieldTypeId,
                        principalTable: "BugNet_ProjectCustomFieldTypes",
                        principalColumn: "CustomFieldTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomField_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_DefaultValues",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    AssignedToNotify = table.Column<bool>(nullable: true),
                    DefaultType = table.Column<int>(nullable: true),
                    IssueAffectedMilestoneId = table.Column<int>(nullable: true),
                    IssueAssignedUserId = table.Column<Guid>(nullable: true),
                    IssueCategoryId = table.Column<int>(nullable: true),
                    IssueDueDate = table.Column<int>(nullable: true),
                    IssueEstimation = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    IssueMilestoneId = table.Column<int>(nullable: true),
                    IssueOwnerUserId = table.Column<Guid>(nullable: true),
                    IssuePriorityId = table.Column<int>(nullable: true),
                    IssueProgress = table.Column<int>(nullable: true),
                    IssueResolutionId = table.Column<int>(nullable: true),
                    IssueVisibility = table.Column<int>(nullable: true),
                    OwnedByNotify = table.Column<bool>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultValues", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_DefaultValues_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectIssueTypes",
                columns: table => new
                {
                    IssueTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueTypeImageUrl = table.Column<string>(nullable: false),
                    IssueTypeName = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueType", x => x.IssueTypeId);
                    table.ForeignKey(
                        name: "FK_IssueType_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectMilestones",
                columns: table => new
                {
                    MilestoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    MilestoneCompleted = table.Column<bool>(nullable: false),
                    MilestoneDueDate = table.Column<DateTime>(nullable: true),
                    MilestoneImageUrl = table.Column<string>(nullable: false),
                    MilestoneName = table.Column<string>(nullable: false),
                    MilestoneNotes = table.Column<string>(nullable: true),
                    MilestoneReleaseDate = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestone", x => x.MilestoneId);
                    table.ForeignKey(
                        name: "FK_Milestone_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectPriorities",
                columns: table => new
                {
                    PriorityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PriorityImageUrl = table.Column<string>(nullable: false),
                    PriorityName = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.PriorityId);
                    table.ForeignKey(
                        name: "FK_Priority_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectNotifications",
                columns: table => new
                {
                    ProjectNotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNotification", x => x.ProjectNotificationId);
                    table.ForeignKey(
                        name: "FK_ProjectNotification_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsClosedState = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    StatusImageUrl = table.Column<string>(nullable: false),
                    StatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_ProjectStatus_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_Queries",
                columns: table => new
                {
                    QueryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPublic = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    QueryName = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Query", x => x.QueryId);
                    table.ForeignKey(
                        name: "FK_Query_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectResolutions",
                columns: table => new
                {
                    ResolutionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    ResolutionImageUrl = table.Column<string>(nullable: false),
                    ResolutionName = table.Column<string>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolution", x => x.ResolutionId);
                    table.ForeignKey(
                        name: "FK_Resolution_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoAssign = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    RoleDescription = table.Column<string>(nullable: false),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Role_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_UserProjects",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SelectedIssueColumns = table.Column<string>(nullable: true),
                    UserProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectCustomFieldSelections",
                columns: table => new
                {
                    CustomFieldSelectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFieldId = table.Column<int>(nullable: false),
                    CustomFieldSelectionName = table.Column<string>(nullable: false),
                    CustomFieldSelectionSortOrder = table.Column<int>(nullable: false),
                    CustomFieldSelectionValue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldSelection", x => x.CustomFieldSelectionId);
                    table.ForeignKey(
                        name: "FK_CustomFieldSelection_CustomField_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "BugNet_ProjectCustomFields",
                        principalColumn: "CustomFieldId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectMailBoxes",
                columns: table => new
                {
                    ProjectMailboxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignToUserId = table.Column<Guid>(nullable: true),
                    IssueTypeId = table.Column<int>(nullable: true),
                    MailBox = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMailbox", x => x.ProjectMailboxId);
                    table.ForeignKey(
                        name: "FK_ProjectMailbox_IssueType_IssueTypeId",
                        column: x => x.IssueTypeId,
                        principalTable: "BugNet_ProjectIssueTypes",
                        principalColumn: "IssueTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectMailbox_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_QueryClauses",
                columns: table => new
                {
                    QueryClauseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BooleanOperator = table.Column<string>(nullable: false),
                    ComparisonOperator = table.Column<string>(nullable: false),
                    CustomFieldId = table.Column<int>(nullable: true),
                    DataType = table.Column<int>(nullable: false),
                    FieldName = table.Column<string>(nullable: false),
                    FieldValue = table.Column<string>(nullable: false),
                    QueryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryClause", x => x.QueryClauseId);
                    table.ForeignKey(
                        name: "FK_QueryClause_Query_QueryId",
                        column: x => x.QueryId,
                        principalTable: "BugNet_Queries",
                        principalColumn: "QueryId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_Issues",
                columns: table => new
                {
                    IssueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueAffectedMilestoneId = table.Column<int>(nullable: true),
                    IssueAssignedUserId = table.Column<Guid>(nullable: true),
                    IssueCategoryId = table.Column<int>(nullable: true),
                    IssueCreatorUserId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IssueDescription = table.Column<string>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    IssueDueDate = table.Column<DateTime>(nullable: true),
                    IssueEstimation = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IssueTitle = table.Column<string>(nullable: false),
                    IssueTypeIssueTypeId = table.Column<int>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    LastUpdateUserId = table.Column<Guid>(nullable: false),
                    IssueOwnerUserId = table.Column<Guid>(nullable: true),
                    IssuePriorityId = table.Column<int>(nullable: true),
                    IssueProgress = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    IssueResolutionId = table.Column<int>(nullable: true),
                    IssueStatusId = table.Column<int>(nullable: true),
                    IssueTypeId = table.Column<int>(nullable: true),
                    IssueVisibility = table.Column<int>(nullable: false),
                    IssueMilestoneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_Issue_Milestone_AffectedMilestoneId",
                        column: x => x.IssueAffectedMilestoneId,
                        principalTable: "BugNet_ProjectMilestones",
                        principalColumn: "MilestoneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_Category_CategoryId",
                        column: x => x.IssueCategoryId,
                        principalTable: "BugNet_ProjectCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_IssueType_IssueTypeIssueTypeId",
                        column: x => x.IssueTypeIssueTypeId,
                        principalTable: "BugNet_ProjectIssueTypes",
                        principalColumn: "IssueTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_Priority_PriorityId",
                        column: x => x.IssuePriorityId,
                        principalTable: "BugNet_ProjectPriorities",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugNet_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issue_Resolution_ResolutionId",
                        column: x => x.IssueResolutionId,
                        principalTable: "BugNet_ProjectResolutions",
                        principalColumn: "ResolutionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_ProjectStatus_StatusId",
                        column: x => x.IssueStatusId,
                        principalTable: "BugNet_ProjectStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_Milestone_ilestoneId",
                        column: x => x.IssueMilestoneId,
                        principalTable: "BugNet_ProjectMilestones",
                        principalColumn: "MilestoneId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_ProjectCustomFieldValues",
                columns: table => new
                {
                    CustomFieldValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFieldId = table.Column<int>(nullable: false),
                    IssueId = table.Column<int>(nullable: false),
                    CustomFieldValue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldValue", x => x.CustomFieldValueId);
                    table.ForeignKey(
                        name: "FK_CustomFieldValue_CustomField_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "BugNet_ProjectCustomFields",
                        principalColumn: "CustomFieldId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomFieldValue_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_IssueAttachments",
                columns: table => new
                {
                    IssueAttachmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attachment = table.Column<byte[]>(nullable: true),
                    ContentType = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    FileSize = table.Column<int>(nullable: false),
                    IssueId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueAttachment", x => x.IssueAttachmentId);
                    table.ForeignKey(
                        name: "FK_IssueAttachment_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_IssueComments",
                columns: table => new
                {
                    IssueCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IssueId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueComment", x => x.IssueCommentId);
                    table.ForeignKey(
                        name: "FK_IssueComment_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_IssueHistory",
                columns: table => new
                {
                    IssueHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FieldChanged = table.Column<string>(nullable: false),
                    IssueId = table.Column<int>(nullable: false),
                    NewValue = table.Column<string>(nullable: false),
                    OldValue = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueHistory", x => x.IssueHistoryId);
                    table.ForeignKey(
                        name: "FK_IssueHistory_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_IssueNotifications",
                columns: table => new
                {
                    IssueNotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueNotification", x => x.IssueNotificationId);
                    table.ForeignKey(
                        name: "FK_IssueNotification_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_IssueRevisions",
                columns: table => new
                {
                    IssueRevisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch = table.Column<string>(nullable: true),
                    Changeset = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IssueId = table.Column<int>(nullable: false),
                    Repository = table.Column<string>(nullable: false),
                    Revision = table.Column<int>(nullable: false),
                    RevisionAuthor = table.Column<string>(nullable: false),
                    RevisionDate = table.Column<string>(nullable: false),
                    RevisionMessage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueRevision", x => x.IssueRevisionId);
                    table.ForeignKey(
                        name: "FK_IssueRevision_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_IssueVotes",
                columns: table => new
                {
                    IssueVoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IssueId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueVote", x => x.IssueVoteId);
                    table.ForeignKey(
                        name: "FK_IssueVote_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_IssueWorkReports",
                columns: table => new
                {
                    IssueWorkReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    IssueCommentId = table.Column<int>(nullable: false),
                    IssueId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    WorkDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueWorkReport", x => x.IssueWorkReportId);
                    table.ForeignKey(
                        name: "FK_IssueWorkReport_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BugNet_RelatedIssues",
                columns: table => new
                {
                    PrimaryIssueId = table.Column<int>(nullable: false),
                    SecondaryIssueId = table.Column<int>(nullable: false),
                    RelationType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedIssue", x => new { x.PrimaryIssueId, x.SecondaryIssueId, x.RelationType });
                    table.ForeignKey(
                        name: "FK_RelatedIssue_Issue_PrimaryIssueId",
                        column: x => x.PrimaryIssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatedIssue_Issue_SecondaryIssueId",
                        column: x => x.SecondaryIssueId,
                        principalTable: "BugNet_Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                nullable: false);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropTable("BugNet_ApplicationLog");
            migrationBuilder.DropTable("BugNet_ProjectCustomFieldSelections");
            migrationBuilder.DropTable("BugNet_ProjectCustomFieldValues");
            migrationBuilder.DropTable("BugNet_DefaultValues");
            migrationBuilder.DropTable("BugNet_DefaultValuesVisibility");
            migrationBuilder.DropTable("BugNet_HostSettings");
            migrationBuilder.DropTable("BugNet_IssueAttachments");
            migrationBuilder.DropTable("BugNet_IssueComments");
            migrationBuilder.DropTable("BugNet_IssueHistory");
            migrationBuilder.DropTable("BugNet_IssueNotifications");
            migrationBuilder.DropTable("BugNet_IssueRevisions");
            migrationBuilder.DropTable("BugNet_IssueVotes");
            migrationBuilder.DropTable("BugNet_IssueWorkReports");
            migrationBuilder.DropTable("BugNet_Languages");
            migrationBuilder.DropTable("BugNet_ProjectMailBoxes");
            migrationBuilder.DropTable("BugNet_ProjectNotifications");
            migrationBuilder.DropTable("BugNet_QueryClauses");
            migrationBuilder.DropTable("BugNet_RelatedIssues");
            migrationBuilder.DropTable("BugNet_RequiredFieldList");
            migrationBuilder.DropTable("BugNet_Roles");
            migrationBuilder.DropTable("BugNet_UserProjects");
            migrationBuilder.DropTable("BugNet_ProjectCustomFields");
            migrationBuilder.DropTable("BugNet_Queries");
            migrationBuilder.DropTable("BugNet_Issues");
            migrationBuilder.DropTable("BugNet_ProjectCustomFieldTypes");
            migrationBuilder.DropTable("BugNet_ProjectMilestones");
            migrationBuilder.DropTable("BugNet_ProjectCategories");
            migrationBuilder.DropTable("BugNet_ProjectIssueTypes");
            migrationBuilder.DropTable("BugNet_ProjectPriorities");
            migrationBuilder.DropTable("BugNet_ProjectResolutions");
            migrationBuilder.DropTable("BugNet_ProjectStatus");
            migrationBuilder.DropTable("BugNet_Projects");
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
