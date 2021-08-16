using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.VersionPage
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Version Version { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Version = await _context.Versions
                .Include(v => v.Skill).FirstOrDefaultAsync(m => m.Id == id);

            if (Version == null)
            {
                return NotFound();
            }
           ViewData["SkillId"] = new SelectList(_context.TblEmployeeRequestSkills, "FldEmployeeRequestSkillsId", "FldEmployeeRequestSkillsId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Version).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersionExists(Version.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VersionExists(long id)
        {
            return _context.Versions.Any(e => e.Id == id);
        }
    }
}
