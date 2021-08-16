using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.VersionPage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int SkillId { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                SkillId = id.Value;
                ViewData["SkillId"] = new SelectList(_context.TblEmployeeRequestSkills.Where(a => a.FldEmployeeRequestSkillsId == id), "FldEmployeeRequestSkillsId", "FldEmployeeRequestSkillsId");
            }
            else
            {
                ViewData["SkillId"] = new SelectList(_context.TblEmployeeRequestSkills, "FldEmployeeRequestSkillsId", "FldEmployeeRequestSkillsId");
            }
            return Page();
        }

        [BindProperty]
        public Models.Version Version { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Versions.Add(Version);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
