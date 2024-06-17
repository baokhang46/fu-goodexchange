using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Model;

namespace FUGoodsExchange.Pages.ModeratorHomePage.sample
{
    public class CreateModel : PageModel
    {
        private readonly BussinessObject.Model.FugoodexchangeContext _context;

        public CreateModel(BussinessObject.Model.FugoodexchangeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BuyerId"] = new SelectList(_context.Buyers, "BuyerId", "BuyerId");
        ViewData["SellerId"] = new SelectList(_context.Sellers, "SellerId", "SellerId");
            return Page();
        }

        [BindProperty]
        public Report Report { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reports.Add(Report);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
