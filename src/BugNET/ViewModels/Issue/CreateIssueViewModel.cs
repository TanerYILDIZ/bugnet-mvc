
namespace BugNET.ViewModels.Issue
{
    using Microsoft.AspNet.Mvc.Rendering;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateIssueViewModel
    {
        [ScaffoldColumn(false)]
        [Key]
        public int IssueId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "An issue title is required")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Affected Milestone")]
        public int? AffectedMilestoneId { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Estimation")]
        public decimal Estimation { get; set; }

        [Display(Name = "Milestone")]
        public int? MilestoneId { get; set; }

        [Display(Name = "Priority")]
        public int? PriorityId { get; set; }

        [Display(Name = "Resolution")]
        public int? ResolutionId { get; set; }

        [Display(Name = "Status")]
        public int? StatusId { get; set; }

        [Display(Name = "Type")]
        public int? IssueTypeId { get; set; }

        [Display(Name = "Visibility")]
        public bool Visibility { get; set; }

        [Display(Name = "Assigned To")]
        public Guid? AssignedUserId { get; set; }

        [Display(Name = "Owner")]
        public string OwnerUserId { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<SelectListItem> Priorities { get; set; }
        public IEnumerable<SelectListItem> Resolutions { get; set; }
        public IEnumerable<SelectListItem> IssueTypes { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public IEnumerable<SelectListItem> Milestones { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public BugNet_DefaultValuesVisibility VisiblityDefaults { get; set; }

    }
}
