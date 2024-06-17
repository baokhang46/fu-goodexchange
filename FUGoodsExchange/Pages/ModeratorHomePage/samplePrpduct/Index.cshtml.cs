using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model;

namespace FUGoodsExchange.Pages.ModeratorHomePage.samplePrpduct
{
    public class IndexModel : PageModel
    {
        private readonly BussinessObject.Model.FugoodexchangeContext _context;

        public IndexModel(BussinessObject.Model.FugoodexchangeContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller).ToListAsync();
        }
    }
}
