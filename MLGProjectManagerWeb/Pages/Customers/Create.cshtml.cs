using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.CustomerService;

namespace MLGProjectManagerWeb.Pages.Customers
{
    public class CreateModel : PageModel
    {

        private readonly ICustomerService _customerService;

        public CreateModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerEntity CustomerEntity { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerService.Add(CustomerEntity);

            return RedirectToPage("/Customers/List");
        }
    }
}
