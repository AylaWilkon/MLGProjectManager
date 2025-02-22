using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MLGProjectManagerWeb.Models;
using Services.CustomerService;

namespace MLGProjectManagerWeb.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly ICustomerService _customerService;

        public EditModel(IProjectService projectService, ICustomerService customerService)
        {
            _projectService = projectService;
            _customerService = customerService;
        }

        [BindProperty]
        public ProjectModel ProjectEntity { get; set; } = default!;

        [BindProperty]
        public string ProjectNumber { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var allProjects = _projectService.GetAll().Result;
            if (id == null)
            {
                return NotFound();
            }

            var projectentity = allProjects.FirstOrDefault(m => m.Id == id);
            if (projectentity == null)
            {
                return NotFound();
            }
            ProjectEntity = ProjectEntityToProjectModelMapper.Map(projectentity);
            ProjectNumber = projectentity.ProjectNumber;
            

            ViewData["CustomerId"] = new SelectList(_customerService.GetAll().Result, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _projectService.UpdateProject(ProjectModelToProjectEntityMapper.Map(ProjectEntity, ProjectNumber));
            
            return RedirectToPage("/Projects/List");
        }
    }
}
