using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.CustomerService;

namespace MLGProjectManagerWeb.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public EditModel(ICustomerService customerService)
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

            var customerentity =  _customerService.GetAll().Result.FirstOrDefault(m => m.Id == id);
            if (customerentity == null)
            {
                return NotFound();
            }
            CustomerEntity = customerentity;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _customerService.Update(CustomerEntity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerEntityExists(CustomerEntity.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Customers/List");
        }

        private bool CustomerEntityExists(int id)
        {
            return _customerService.GetAll().Result.Any(e => e.Id == id);
        }
    }
}
