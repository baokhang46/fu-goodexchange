using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model;
using Services;
using System.Text.RegularExpressions;

namespace FUGoodsExchange.Pages.MangeAccount
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;


        public EditModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var loginAccount = HttpContext.Session.GetString("UserEmail");
            var currAcc = _accountService.GetAccountByEmail(loginAccount);

            if (loginAccount == null)
            {
                return RedirectToPage("/Login");
            }
            if (id == null)
            {
                return NotFound();
            }
            if (currAcc == null || currAcc.Role == null)
            {
                var account = _accountService.GetAccountById((int)id);
                if (account == null)
                {
                    return NotFound();
                }
                Account = account;
                ViewData["Id"] = account.AccountId;
                ViewData["Name"] = account.Username;
                ViewData["Password"] = account.Password;
                ViewData["Email"] = account.Email;

                Account.Role = account.Role;
                return Page();
            }
            else if (currAcc.Role == "Moderator" || currAcc.Role == "Buyer" || currAcc.Role == "Seller")
            {
                return RedirectToPage("/PageNotFound");
            }
            else
            {
                return Page();
            }
        }

        private bool EmailIsExisted(string email)
        {
            var currentAccount = HttpContext.Session.GetString("UserMail");
            try
            {
                var account = _accountService.GetAccountByEmail(currentAccount);
                if (account != null && !account.Email.Equals(currentAccount))
                {
                    ErrorMessage = "Email is already have";
                    ModelState.AddModelError(string.Empty, ErrorMessage);
                    return false;

                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Failed";
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            return false;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!EmailIsExisted(Account.Email))
            {

                _accountService.UpdateAccount(Account);

            }
            return RedirectToPage("./Index");

        }
    }
}
