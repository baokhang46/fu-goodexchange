using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FUGoodsExchange.Pages.AdminHomePage
{
    
    public class AdminHomePageModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToPage("/AccessDenied");
            }
            return Page();
        }
    }
}
