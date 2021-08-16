using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.OutlinePage
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<Outline> Outline { get;set; }

        public async Task OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                Outline = await _context.Outlines.ToListAsync();
            }
            Outline = await _context.Outlines.ToListAsync();
        }
    }
}
