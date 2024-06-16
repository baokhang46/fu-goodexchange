using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using BussinessObject.Model;
using Services;
using FUGoodsExchange.Security;

namespace FUGoodsExchange.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {          

            var account = _accountService.GetAccountByEmail(Account.Email);
            if (account == null || !PasswordHasher.VerifyPassword(Account.Password, account.Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            HttpContext.Session.SetString("UserEmail", account.Email);

            if (account.Role == "Admin")
            {
                HttpContext.Session.SetString("UserRole", "Admin");
                return RedirectToPage("/AdminHomePage/AdminHomePage");
            }
            else if (account.Role == "Moderator")
            {
                HttpContext.Session.SetString("UserRole", "Moderator");
                return RedirectToPage("/ModeratorHomePage/ModeratorHomePage");
            }
            else if (account.Role == "Buyer")
            {
                HttpContext.Session.SetString("UserRole", "Buyer");
                return RedirectToPage("/BuyerHomePage/BuyerHomePage");
            }
            else if (account.Role == "Seller")
            {
                HttpContext.Session.SetString("UserRole", "Seller");
                return RedirectToPage("/SellerHomePage/SellerHomePage");
            }
            else
            {              
                return RedirectToPage("./Index");
            }
        }
    }
}
