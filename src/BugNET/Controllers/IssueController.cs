using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BugNET.Models;
using BugNET.ViewModels.Issue;

namespace BugNET.Controllers
{
    public class IssueController : Controller
    {
        private ApplicationDbContext _context;

        public IssueController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Issue
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BugNet_Issues.Include(b => b.IssueAffectedMilestone).Include(b => b.IssueAssignedUser).Include(b => b.IssueCategory).Include(b => b.IssueCreatorUser).Include(b => b.IssueMilestone).Include(b => b.IssueOwnerUser).Include(b => b.IssuePriority).Include(b => b.IssueResolution).Include(b => b.IssueStatus).Include(b => b.IssueType).Include(b => b.LastUpdateUser).Include(b => b.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Issue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BugNet_Issues bugNet_Issues = await _context.BugNet_Issues.SingleAsync(m => m.IssueId == id);
            if (bugNet_Issues == null)
            {
                return HttpNotFound();
            }

            return View(bugNet_Issues);
        }

        // GET: Issue/Create
        public IActionResult Create()
        {
            ViewData["IssueAffectedMilestoneId"] = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueAffectedMilestone");
            ViewData["IssueAssignedUserId"] = new SelectList(_context.Users, "Id", "IssueAssignedUser");
            ViewData["IssueCategoryId"] = new SelectList(_context.BugNet_ProjectCategories, "CategoryId", "IssueCategory");
            ViewData["IssueCreatorUserId"] = new SelectList(_context.Users, "Id", "IssueCreatorUser");
            ViewData["IssueMilestoneId"] = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueMilestone");
            ViewData["IssueOwnerUserId"] = new SelectList(_context.Users, "Id", "IssueOwnerUser");
            ViewData["IssuePriorityId"] = new SelectList(_context.BugNet_ProjectPriorities, "PriorityId", "IssuePriority");
            ViewData["IssueResolutionId"] = new SelectList(_context.BugNet_ProjectResolutions, "ResolutionId", "IssueResolution");
            ViewData["IssueStatusId"] = new SelectList(_context.BugNet_ProjectStatus, "StatusId", "IssueStatus");
            ViewData["IssueTypeId"] = new SelectList(_context.BugNet_ProjectIssueTypes, "IssueTypeId", "IssueType");
            ViewData["LastUpdateUserId"] = new SelectList(_context.Users, "Id", "LastUpdateUser");
            ViewData["ProjectId"] = new SelectList(_context.BugNet_Projects, "ProjectId", "Project");
            return View();
        }

        public IActionResult Create1()
        {
            BugNet_DefaultValuesVisibility visibility = new BugNet_DefaultValuesVisibility();
            BugNet_DefaultValues defaultValues = new BugNet_DefaultValues();

            var viewModel = new CreateIssueViewModel()
            {              
                //AffectedMilestones = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueAffectedMilestone"),
                Categories = new SelectList(_context.BugNet_ProjectCategories, "CategoryId", "IssueCategory"),
                Milestones = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueMilestone"),
                Users = new SelectList(_context.Users, "Id", "IssueOwnerUser"),
                Priorities = new SelectList(_context.BugNet_ProjectPriorities, "PriorityId", "IssuePriority"),
                Resolutions = new SelectList(_context.BugNet_ProjectResolutions, "ResolutionId", "IssueResolution"),
                Status = new SelectList(_context.BugNet_ProjectStatus, "StatusId", "IssueStatus"),
                IssueTypes = new SelectList(_context.BugNet_ProjectIssueTypes, "IssueTypeId", "IssueType"),
                VisiblityDefaults = visibility
            };

            return View(viewModel);
        }

        // POST: Issue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BugNet_Issues bugNet_Issues)
        {
            if (ModelState.IsValid)
            {
                _context.BugNet_Issues.Add(bugNet_Issues);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IssueAffectedMilestoneId"] = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueAffectedMilestone", bugNet_Issues.IssueAffectedMilestoneId);
            ViewData["IssueAssignedUserId"] = new SelectList(_context.Users, "Id", "IssueAssignedUser", bugNet_Issues.IssueAssignedUserId);
            ViewData["IssueCategoryId"] = new SelectList(_context.BugNet_ProjectCategories, "CategoryId", "IssueCategory", bugNet_Issues.IssueCategoryId);
            ViewData["IssueCreatorUserId"] = new SelectList(_context.Users, "Id", "IssueCreatorUser", bugNet_Issues.IssueCreatorUserId);
            ViewData["IssueMilestoneId"] = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueMilestone", bugNet_Issues.IssueMilestoneId);
            ViewData["IssueOwnerUserId"] = new SelectList(_context.Users, "Id", "IssueOwnerUser", bugNet_Issues.IssueOwnerUserId);
            ViewData["IssuePriorityId"] = new SelectList(_context.BugNet_ProjectPriorities, "PriorityId", "IssuePriority", bugNet_Issues.IssuePriorityId);
            ViewData["IssueResolutionId"] = new SelectList(_context.BugNet_ProjectResolutions, "ResolutionId", "IssueResolution", bugNet_Issues.IssueResolutionId);
            ViewData["IssueStatusId"] = new SelectList(_context.BugNet_ProjectStatus, "StatusId", "IssueStatus", bugNet_Issues.IssueStatusId);
            ViewData["IssueTypeId"] = new SelectList(_context.BugNet_ProjectIssueTypes, "IssueTypeId", "IssueType", bugNet_Issues.IssueTypeId);
            ViewData["LastUpdateUserId"] = new SelectList(_context.Users, "Id", "LastUpdateUser", bugNet_Issues.LastUpdateUserId);
            ViewData["ProjectId"] = new SelectList(_context.BugNet_Projects, "ProjectId", "Project", bugNet_Issues.ProjectId);
            return View(bugNet_Issues);
        }

        // GET: Issue/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BugNet_Issues bugNet_Issues = await _context.BugNet_Issues.SingleAsync(m => m.IssueId == id);
            if (bugNet_Issues == null)
            {
                return HttpNotFound();
            }
            ViewData["IssueAffectedMilestoneId"] = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueAffectedMilestone", bugNet_Issues.IssueAffectedMilestoneId);
            ViewData["IssueAssignedUserId"] = new SelectList(_context.Users, "Id", "IssueAssignedUser", bugNet_Issues.IssueAssignedUserId);
            ViewData["IssueCategoryId"] = new SelectList(_context.BugNet_ProjectCategories, "CategoryId", "IssueCategory", bugNet_Issues.IssueCategoryId);
            ViewData["IssueCreatorUserId"] = new SelectList(_context.Users, "Id", "IssueCreatorUser", bugNet_Issues.IssueCreatorUserId);
            ViewData["IssueMilestoneId"] = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueMilestone", bugNet_Issues.IssueMilestoneId);
            ViewData["IssueOwnerUserId"] = new SelectList(_context.Users, "Id", "IssueOwnerUser", bugNet_Issues.IssueOwnerUserId);
            ViewData["IssuePriorityId"] = new SelectList(_context.BugNet_ProjectPriorities, "PriorityId", "IssuePriority", bugNet_Issues.IssuePriorityId);
            ViewData["IssueResolutionId"] = new SelectList(_context.BugNet_ProjectResolutions, "ResolutionId", "IssueResolution", bugNet_Issues.IssueResolutionId);
            ViewData["IssueStatusId"] = new SelectList(_context.BugNet_ProjectStatus, "StatusId", "IssueStatus", bugNet_Issues.IssueStatusId);
            ViewData["IssueTypeId"] = new SelectList(_context.BugNet_ProjectIssueTypes, "IssueTypeId", "IssueType", bugNet_Issues.IssueTypeId);
            ViewData["LastUpdateUserId"] = new SelectList(_context.Users, "Id", "LastUpdateUser", bugNet_Issues.LastUpdateUserId);
            ViewData["ProjectId"] = new SelectList(_context.BugNet_Projects, "ProjectId", "Project", bugNet_Issues.ProjectId);
            return View(bugNet_Issues);
        }

        // POST: Issue/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BugNet_Issues bugNet_Issues)
        {
            if (ModelState.IsValid)
            {
                _context.Update(bugNet_Issues);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IssueAffectedMilestoneId"] = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueAffectedMilestone", bugNet_Issues.IssueAffectedMilestoneId);
            ViewData["IssueAssignedUserId"] = new SelectList(_context.Users, "Id", "IssueAssignedUser", bugNet_Issues.IssueAssignedUserId);
            ViewData["IssueCategoryId"] = new SelectList(_context.BugNet_ProjectCategories, "CategoryId", "IssueCategory", bugNet_Issues.IssueCategoryId);
            ViewData["IssueCreatorUserId"] = new SelectList(_context.Users, "Id", "IssueCreatorUser", bugNet_Issues.IssueCreatorUserId);
            ViewData["IssueMilestoneId"] = new SelectList(_context.BugNet_ProjectMilestones, "MilestoneId", "IssueMilestone", bugNet_Issues.IssueMilestoneId);
            ViewData["IssueOwnerUserId"] = new SelectList(_context.Users, "Id", "IssueOwnerUser", bugNet_Issues.IssueOwnerUserId);
            ViewData["IssuePriorityId"] = new SelectList(_context.BugNet_ProjectPriorities, "PriorityId", "IssuePriority", bugNet_Issues.IssuePriorityId);
            ViewData["IssueResolutionId"] = new SelectList(_context.BugNet_ProjectResolutions, "ResolutionId", "IssueResolution", bugNet_Issues.IssueResolutionId);
            ViewData["IssueStatusId"] = new SelectList(_context.BugNet_ProjectStatus, "StatusId", "IssueStatus", bugNet_Issues.IssueStatusId);
            ViewData["IssueTypeId"] = new SelectList(_context.BugNet_ProjectIssueTypes, "IssueTypeId", "IssueType", bugNet_Issues.IssueTypeId);
            ViewData["LastUpdateUserId"] = new SelectList(_context.Users, "Id", "LastUpdateUser", bugNet_Issues.LastUpdateUserId);
            ViewData["ProjectId"] = new SelectList(_context.BugNet_Projects, "ProjectId", "Project", bugNet_Issues.ProjectId);
            return View(bugNet_Issues);
        }

        // GET: Issue/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BugNet_Issues bugNet_Issues = await _context.BugNet_Issues.SingleAsync(m => m.IssueId == id);
            if (bugNet_Issues == null)
            {
                return HttpNotFound();
            }

            return View(bugNet_Issues);
        }

        // POST: Issue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            BugNet_Issues bugNet_Issues = await _context.BugNet_Issues.SingleAsync(m => m.IssueId == id);
            _context.BugNet_Issues.Remove(bugNet_Issues);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
