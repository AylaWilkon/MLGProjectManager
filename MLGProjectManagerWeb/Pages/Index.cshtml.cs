using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public IndexModel()
    { }

    // Handle GET request to retrieve all customers
    public async Task<IActionResult> OnGetAsync()
    {

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
            return RedirectToPage(); // Reload the page after adding the project
    }




}