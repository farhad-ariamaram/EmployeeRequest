using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.VersionWebsiteTablePage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public long VersionId { get; set; }

        public IActionResult OnGet(long id)
        {
            VersionId = id;
            ViewData["VersionId"] = new SelectList(_context.Versions, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public VersionWebsiteTable VersionWebsiteTable { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                VersionId = VersionWebsiteTable.VersionId;
                return Page();
            }

            _context.VersionWebsiteTables.Add(VersionWebsiteTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = VersionWebsiteTable.VersionId });
        }
    }
}
