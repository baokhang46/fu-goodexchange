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
        private readonly BussinessObject.Model.FugoodexchangeContext _context;
        private readonly ICategoryService _categoryService;
        public CreateModel(BussinessObject.Model.FugoodexchangeContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _categoryService.createCategory(Category);

            return RedirectToPage("./Index");
        }
    }
}
