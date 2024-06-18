using BussinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services;

namespace FUGoodsExchange.Pages.ModeratorHomePage
{
    public class ViewDetailProductModel : PageModel
    {
        private readonly IProductService _productService;

        public ViewDetailProductModel(IProductService productService)
        {
            _productService = productService;
        }

        public Product Product { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            Product = _productService.GetProductById(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
