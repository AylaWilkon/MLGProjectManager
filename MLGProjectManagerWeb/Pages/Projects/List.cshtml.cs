using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MLGProjectManagerWeb.Pages.Projects
{
    public class ListModel : PageModel
    {
        private readonly IProjectService _projectService;

        public ListModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IList<ProjectEntity> ProjectEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProjectEntity = await _projectService.GetAll();
        }
    }
}
