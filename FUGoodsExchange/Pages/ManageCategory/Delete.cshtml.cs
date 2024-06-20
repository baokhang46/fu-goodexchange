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
        private readonly BussinessObject.Model.FugoodexchangeContext _context;
        private readonly ICategoryService _categoryService;
        public DeleteModel(BussinessObject.Model.FugoodexchangeContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetCategoryById(id.Value);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetCategoryById(id.Value);
            if (category != null)
            {
                Category = category;
                _categoryService.deleteCategory(category);
            }

            return RedirectToPage("./Index");
        }
    }
}
