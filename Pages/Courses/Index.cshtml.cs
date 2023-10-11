using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Codesome.Data;
using Codesome.Models;

namespace Codesome.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly Codesome.Data.CodesomeContext _context;

        public IndexModel(Codesome.Data.CodesomeContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Course != null)
            {
                Course = await _context.Course.ToListAsync();
            }
        }
    }
}
