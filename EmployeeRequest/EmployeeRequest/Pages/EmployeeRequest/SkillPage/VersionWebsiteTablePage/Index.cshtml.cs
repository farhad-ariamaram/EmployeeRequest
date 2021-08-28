using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            ViewData["id"] = id;
            VersionWebsiteTable = await _context.VersionWebsiteTables
                .Where(a => a.VersionId == id)
                .Include(v => v.Version).ToListAsync();

            return Page();
        }
    }
}
