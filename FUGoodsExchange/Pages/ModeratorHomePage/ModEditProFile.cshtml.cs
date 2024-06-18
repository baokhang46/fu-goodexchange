using BussinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System;

namespace FUGoodsExchange.Pages.ModeratorHomePage
{
    public class ModEditProFileModel : PageModel
    {
        private readonly IUserService _userService;

        public ModEditProFileModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet(int userId = 2)
        {
            User = _userService.GetUserById(userId);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _userService.UpdateUser(User);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in a way appropriate for your application
                ModelState.AddModelError("", "An error occurred while updating the user.");
                return Page();
            }

            return RedirectToPage("/ModeratorHomePage/Index");
        }
    }
}
