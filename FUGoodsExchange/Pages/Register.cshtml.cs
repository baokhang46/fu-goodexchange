using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BussinessObject.Model;
using Services;
using FUGoodsExchange.ViewModels;

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

            var newAccount = new Account
            {
                Username = Account.Username,
                Email = Account.Email,
                Password = Account.Password,
                Status = "Active" 
            };

            _accountService.CreateAccount(newAccount);

            return RedirectToPage("/Login");
        }
    }
}
