using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using BussinessObject.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FUGoodsExchange.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IAccountService _accountService;

        public ForgotPasswordModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string Email { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var account = _accountService.GetAccountByEmail(Email);
            if (account == null)
            {
                ModelState.AddModelError(string.Empty, "Email not found.");
                return Page();
            }

            return RedirectToPage("ResetPassword", new { accountId = account.AccountId });
        }
    }
}
