using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BussinessObject.Model;
using Services;
using FUGoodsExchange.Pages.Models;
using FUGoodsExchange.Security;

namespace FUGoodsExchange.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;

        public RegisterModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public RegisterViewModel Account { get; set; } = new RegisterViewModel();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingAccount = _accountService.GetAccountByEmail(Account.Email);
            if (existingAccount != null)
            {
                ModelState.AddModelError(string.Empty, "Email already in use.");
                return Page();
            }

            string hashedPassword = PasswordHasher.HashPassword(Account.Password);

            var newAccount = new Account
            {
                Username = Account.Username,
                Email = Account.Email,
                Password = hashedPassword,
                Status = "Active",
                Role = "Buyer" 
            };

            _accountService.CreateAccount(newAccount);
            HttpContext.Session.SetString("UserRole", newAccount.Role);
            HttpContext.Session.SetString("UserEmail", newAccount.Email);

            return RedirectToPage("/Login"); 
        }
    }
}
