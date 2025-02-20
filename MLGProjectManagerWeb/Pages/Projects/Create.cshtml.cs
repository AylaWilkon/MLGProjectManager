using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MLGProjectManagerWeb.Models;

namespace MLGProjectManagerWeb.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IProjectService _projectService;
        private List<CustomerEntity> _customerEntities;

        public CreateModel(ICustomerService customerService, IProjectService projectService)
        {
            _customerService = customerService;
            _projectService = projectService;
            _customerEntities = _customerService.GetAll().Result;
        }

        public IActionResult OnGet()
        {
            var customers = new SelectList(_customerEntities, "Id", "Name");
            ViewData["CustomerId"] = customers;
            return Page();
        }

        [BindProperty]
        public ProjectModel ProjectModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _projectService.AddProject(ProjectModelToProjectEntityMapper.Map(ProjectModel, string.Empty));

            return RedirectToPage("/Projects/List");
        }
    }
}
