using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.VersionWebsiteTablePage
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<VersionWebsiteTable> VersionWebsiteTable { get; set; }

        public async Task OnGetAsync(int id)
        {
            ViewData["id"] = id;
            VersionWebsiteTable = await _context.VersionWebsiteTables
                .Where(a => a.VersionId == id)
                .Include(v => v.Version).ToListAsync();
        }
    }
}
