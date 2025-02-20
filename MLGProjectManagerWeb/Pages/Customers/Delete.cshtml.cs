using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.CustomerService;

namespace MLGProjectManagerWeb.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public DeleteModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public CustomerEntity CustomerEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerentity = _customerService.GetAll().Result.FirstOrDefault(m => m.Id == id);

            if (customerentity is not null)
            {
                CustomerEntity = customerentity;

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

            _ = await _customerService.Delete((int)id);

            return RedirectToPage("/Customers/List");
        }
    }
}
