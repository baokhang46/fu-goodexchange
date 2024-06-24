using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model;
using Services;

namespace FUGoodsExchange.Pages.ManageCategory
{
    public class DeleteModel : PageModel
    {
		private readonly ICategoryService _accountService = null;

		public DeleteModel(ICategoryService accountService)
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
			else
			{
				Category = account;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(short id)
		{
			if (id == null || _accountService.GetCategories() == null)
			{
				return NotFound();
			}
			var account = _accountService.GetCategory(id);

			if (account != null)
			{
				_accountService.DeleteCategory(id);
			}

			return RedirectToPage("./Index");
		}
	}
}
