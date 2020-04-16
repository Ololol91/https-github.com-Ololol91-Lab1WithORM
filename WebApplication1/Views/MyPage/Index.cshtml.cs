using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scaffolding.Models;
using WebApplication1.Models;

namespace WebApplication1.Views.MyPage
{
    public class IndexModel : PageModel
    {
        private readonly ScladContext _context;
        
        public IndexModel(ScladContext context)
        {
            _context = context;
        }

        public IList<Country> countries { get; set; }
        
        public async Task OnGetAsync()
        {
            countries = await _context.Countries.ToListAsync();
        }
    }
}