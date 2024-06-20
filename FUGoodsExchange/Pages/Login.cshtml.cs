using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            HttpContext.Session.SetString("UserId", account.AccountId.ToString());
            HttpContext.Session.SetString("UserEmail", account.Email);
            HttpContext.Session.SetString("UserRole", account.Role);

            return RedirectToRoleHomePage(account.Role);
        }

        private IActionResult RedirectToRoleHomePage(string role)
        {
            return role switch
            {
                "Admin" => RedirectToPage("/AdminPage/AdminHomePage"),
                "Moderator" => RedirectToPage("/ModeratorHomePage/ModeratorHomePage"),
                "Buyer" => RedirectToPage("/BuyerHomePage/BuyerHomePage"),
                "Seller" => RedirectToPage("/SellerHomePage/SellerHomePage"),
                _ => RedirectToPage("./Index"),
            };
        }
    }
}
