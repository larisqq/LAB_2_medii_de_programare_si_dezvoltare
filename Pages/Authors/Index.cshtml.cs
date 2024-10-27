using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LAB_2.Data;
using LAB_2.Models;

namespace LAB_2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly LAB_2.Data.LAB_2Context _context;

        public IndexModel(LAB_2.Data.LAB_2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
