using BussinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace FUGoodsExchange.Pages.ModeratorHomePage
{
    public class ViewReportModel : PageModel
    {
        private readonly IReportService _reportService;

        public ViewReportModel(IReportService reportService)
        {
            _reportService = reportService;
        }
        public IList<Report> Report { get; set; } = default!;
        public IActionResult OnGet()
        {
            Report = _reportService.GetAllReports();
            return Page();
        }
    }
}
