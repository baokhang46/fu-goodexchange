using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model;

namespace FUGoodsExchange.Pages.ModeratorHomePage.sample
{
    public class IndexModel : PageModel
    {
        private readonly BussinessObject.Model.FugoodexchangeContext _context;

        public IndexModel(BussinessObject.Model.FugoodexchangeContext context)
        {
            _context = context;
        }

        public IList<Report> Report { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Report = await _context.Reports
                .Include(r => r.Buyer)
                .Include(r => r.Seller).ToListAsync();
        }
    }
}
