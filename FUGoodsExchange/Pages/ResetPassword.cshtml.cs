using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FUGoodsExchange.Security;
using Services;
using System.Threading.Tasks;

namespace FUGoodsExchange.Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IAccountService _accountService;

        public ResetPasswordModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public int AccountId { get; set; }

        public void OnGet(int accountId)
        {
            AccountId = accountId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NewPassword != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "The password and confirmation password do not match.");
                return Page();
            }

            var account = _accountService.GetAccountById(AccountId);
            if (account == null)
            {
                ModelState.AddModelError(string.Empty, "Account not found.");
                return Page();
            }

            var hashedPassword = PasswordHasher.HashPassword(NewPassword);
            _accountService.UpdatePassword(AccountId, hashedPassword);

            return RedirectToPage("/Login");
        }
    }
}
