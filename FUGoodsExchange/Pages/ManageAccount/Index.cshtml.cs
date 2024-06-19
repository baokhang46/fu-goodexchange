using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model;
using Services;

namespace FUGoodsExchange.Pages.MangeAccount
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<Account> Account { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SortOption { get; set; } = "name-asc";

        [BindProperty(SupportsGet = true)]
        public string FilterOption { get; set; } = "all";

        public async Task OnGetAsync()
        {
 
            Account = _accountService.GetAllAccounts();
            var searchAcc = _accountService.SearchAccounts(SearchTerm, SortOption, FilterOption);
        }
    }
}
