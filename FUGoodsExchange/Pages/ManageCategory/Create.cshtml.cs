using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Model;
using Services;

namespace FUGoodsExchange.Pages.ManageCategory
{
    public class CreateModel : PageModel
    {
		private readonly ICategoryService _accountService;

		public CreateModel(ICategoryService accountService)
		{
			_accountService = accountService;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Category Category { get; set; } = default!;
		public string ErrorMessage { get; set; }


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _accountService.GetCategories() == null || Category == null)
			{
				return Page();
			}

			try
			{
				_accountService.AddCategory(Category);
				return RedirectToPage("./Index");
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return Page();
			}
		}
	}
}
