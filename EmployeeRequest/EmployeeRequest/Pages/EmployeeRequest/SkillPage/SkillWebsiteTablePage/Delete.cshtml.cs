using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.SkillWebsiteTablePage
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SkillWebsiteTable SkillWebsiteTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SkillWebsiteTable = await _context.SkillWebsiteTables
                .Include(s => s.Skill).FirstOrDefaultAsync(m => m.Id == id);

            if (SkillWebsiteTable == null)
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

            SkillWebsiteTable = await _context.SkillWebsiteTables.FindAsync(id);

            if (SkillWebsiteTable != null)
            {
                _context.SkillWebsiteTables.Remove(SkillWebsiteTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = SkillWebsiteTable.SkillId });
        }
    }
}
