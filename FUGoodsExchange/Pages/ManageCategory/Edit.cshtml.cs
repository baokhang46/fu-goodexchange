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

namespace FUGoodsExchange.Pages.ManageCategory
{
    public class EditModel : PageModel
    {
		private readonly ICategoryService _accountService = null;

		public EditModel(ICategoryService accountService)
		{
			_accountService = accountService;
		}

		[BindProperty]
		public Category Category { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(short id)
		{
			if (id == null || _accountService.GetCategories() == null)
			{
				return NotFound();
			}

			var account = _accountService.GetCategory(id);
			if (account == null)
			{
				return NotFound();
			}
			Category = account;
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}



			try
			{
				_accountService.UpdateCategory(Category);
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;

			}

			return RedirectToPage("./Index");
		}
	}
}
