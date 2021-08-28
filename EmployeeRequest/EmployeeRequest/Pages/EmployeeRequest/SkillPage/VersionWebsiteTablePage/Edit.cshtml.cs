using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.VersionWebsiteTablePage
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
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
           ViewData["VersionId"] = new SelectList(_context.Versions, "Id", "Version1");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VersionWebsiteTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersionWebsiteTableExists(VersionWebsiteTable.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = VersionWebsiteTable.VersionId });
        }

        private bool VersionWebsiteTableExists(int id)
        {
            return _context.VersionWebsiteTables.Any(e => e.Id == id);
        }
    }
}
