using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BussinessObject.Model;
using Services;

namespace FUGoodsExchange.Pages.ManageAccount
{
    public class ManageAccountModel : PageModel
    {
        private readonly IAccountService _accountService;

        public ManageAccountModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<Account> Accounts { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SortOption { get; set; } = "name-asc";

        [BindProperty(SupportsGet = true)]
        public string FilterOption { get; set; } = "all";

        [BindProperty]
        public Account Account { get; set; } = default!;

        [BindProperty]
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToPage("/AccessDenied");
            }

            Accounts = _accountService.GetAllAccounts();

            if (!string.IsNullOrEmpty(SearchTerm) || !string.IsNullOrEmpty(SortOption) || !string.IsNullOrEmpty(FilterOption))
            {
                Accounts = _accountService.SearchAccounts(SearchTerm, SortOption, FilterOption);
            }

            if (id != null)
            {
                var account = _accountService.GetAccountById((int)id);
                if (account != null)
                {
                    Account = account;
                }
            }

            return Page();
        }

        private bool EmailIsExisted(string email)
        {
            try
            {
                var account = _accountService.GetAccountByEmail(email);
                if (account != null && !account.Email.Equals(email))
                {
                    ErrorMessage = "Email already exists";
                    ModelState.AddModelError(string.Empty, ErrorMessage);
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Failed to check email existence";
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            return false;
        }

        public async Task<IActionResult> OnPostUpdateAsync(int? id)
        {
            var chekAccount = HttpContext.Session.GetString("UserRole"); 
            if (chekAccount != "Admin")
            {
                return RedirectToPage("/AccessDenied");
            }

            if (EmailIsExisted(Account.Email))
            {
                return Page();
            }

            try
            {
                var existingAccount = _accountService.GetAccountById((int)id);
                if (existingAccount == null)
                {
                    return NotFound();
                }

                existingAccount.Role = Account.Role;

                _accountService.UpdateAccount(existingAccount);
                return RedirectToPage("./ManageAccountPage");
            }
            catch (Exception ex)
            {
                ErrorMessage = "Failed to update account";
                ModelState.AddModelError(string.Empty, ErrorMessage);
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeactivateAsync(int? id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToPage("/AccessDenied");
            }

            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var account = _accountService.GetAccountById((int)id);
                if (account == null)
                {
                    return NotFound();
                }

                account.Status = "Inactive";
                _accountService.DeactivateAccount(account);

                return RedirectToPage("./ManageAccountPage");
            }
            catch (Exception ex)
            {
                ErrorMessage = "Failed to deactivate account";
                ModelState.AddModelError(string.Empty, ErrorMessage);
                return Page();
            }
        }
    }
}
