using BussinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace FUGoodsExchange.Pages.ModeratorHomePage
{
    public class ViewAllProductModModel : PageModel
    {
        private readonly IProductService _productService;

        public ViewAllProductModModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> Product { get; set; } = default!;

        public IActionResult OnGet()
        {
            Product = _productService.GetAllProducts();
            return Page();
        }

    }
}
