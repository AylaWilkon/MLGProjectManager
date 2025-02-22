using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MLGProjectManagerWeb.Pages.Projects
    //READ: visar detaljer för ett specifikt projekt i webappen.
{
    public class DetailsModel : PageModel
    {
        private readonly IProjectService _projectService;

        public DetailsModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public ProjectEntity ProjectEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectentity = _projectService.Get((int)id);

            if (projectentity is not null)
            {
                ProjectEntity = await projectentity;

                return Page();
            }

            return NotFound();
        }
    }
}
