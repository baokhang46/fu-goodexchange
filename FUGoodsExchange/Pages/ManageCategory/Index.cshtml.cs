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
    public class IndexModel : PageModel
    {
		private readonly ICategoryService _iCateService;

		public IndexModel(ICategoryService iCateService)
		{
			_iCateService = iCateService;
		}

		public IList<Category> Category { get; set; } = default!;

		public async Task OnGetAsync()
		{
			var cate = _iCateService.GetCategories();
			if (cate != null)
			{
				Category = cate;
			}
		}

		public async Task<IActionResult> OnPostLogoutAsync()
		{
			HttpContext.Session.Clear();
			return RedirectToPage("/Index");
		}

	}
}
