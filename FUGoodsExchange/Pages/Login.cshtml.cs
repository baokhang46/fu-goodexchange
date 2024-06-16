using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Model;
using Services;
using FUGoodsExchange.Security;

namespace FUGoodsExchange.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
     

        public LoginModel(IAccountService accountService, 
            IConfiguration configuration,
            PasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _configuration = configuration;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var adminEmail = _configuration["AdminAccount:Email"];
            var adminPassword = _configuration["AdminAccount:Password"];

            if (Account.Email == adminEmail && PasswordHasher.VerifyPassword(Account.Password, adminPassword))
            {
                HttpContext.Session.SetString("UserRole", "Admin");
                HttpContext.Session.SetString("UserEmail", Account.Email);
                return RedirectToPage("/AdminHomePage/AdminHomePage");
            }
            var account = _accountService.GetAccountByEmail(Account.Email);
            if (account == null || PasswordHasher.VerifyPassword(account.Password, Account.Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            HttpContext.Session.SetString("UserRole", account.Role);
            HttpContext.Session.SetString("UserEmail", account.Email);

            switch (account.Role)
            {
                case "Moderator":
                    return RedirectToPage("/ModeratorHomePage/ModeratorHomePage");
                case "Buyer":
                    return RedirectToPage("/BuyerHomePage/BuyerHomePage");
                case "Seller":
                    return RedirectToPage("/SellerHomePage/SellerHomePage");
                default:
                    return RedirectToPage("./Index");
            }

        }
    }
}
