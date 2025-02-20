using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MLGProjectManagerWeb.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly IProjectService _projectService;

        public DeleteModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [BindProperty]
        public ProjectEntity ProjectEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var projects = _projectService.GetAll().Result;
            if (id == null)
            {
                return NotFound();
            }

            var projectentity = projects.FirstOrDefault(m => m.Id == id);

            if (projectentity is not null)
            {
                ProjectEntity = projectentity;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectentity = await _projectService.Delete((int)id);
            

            return RedirectToPage("/Projects/List");
        }
    }
}
