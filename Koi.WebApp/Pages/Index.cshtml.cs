using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Entities;

namespace Koi.WebApp.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly Koi.Repositories.Entities.CaKoiStoreContext _context;

        public IndexModel(Koi.Repositories.Entities.CaKoiStoreContext context)
        {
            _context = context;
        }

        public IList<Koi> Koi { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Koi = await _context.Kois.ToListAsync();
        }
    }
}
