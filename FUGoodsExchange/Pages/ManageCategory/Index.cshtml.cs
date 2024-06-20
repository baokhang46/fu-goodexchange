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
        private readonly BussinessObject.Model.FugoodexchangeContext _context;
        private readonly ICategoryService _categoryService;
        public IndexModel(BussinessObject.Model.FugoodexchangeContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = _categoryService.GetCategories();
        }
    }
}
