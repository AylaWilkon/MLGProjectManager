using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MLGProjectManagerWeb.Pages.Customers
{
    public class CustomersModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public List<CustomerEntity> CustomerEntities = new List<CustomerEntity>();

        public CustomersModel(ICustomerService customerService)
        {

            _customerService = customerService;
        }

        public async Task OnGetAsync(string sortOrder)
        {
            CustomerEntities = await _customerService.GetAll();
        }

    }

}
