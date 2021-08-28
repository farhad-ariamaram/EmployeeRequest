using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.VersionWebsiteTablePage
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VersionWebsiteTable VersionWebsiteTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            VersionWebsiteTable = await _context.VersionWebsiteTables
                .Include(v => v.Version).FirstOrDefaultAsync(m => m.Id == id);

            if (VersionWebsiteTable == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VersionWebsiteTable = await _context.VersionWebsiteTables.FindAsync(id);

            if (VersionWebsiteTable != null)
            {
                _context.VersionWebsiteTables.Remove(VersionWebsiteTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = VersionWebsiteTable.VersionId });
        }
    }
}
