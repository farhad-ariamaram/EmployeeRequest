using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.SkillWebsiteTablePage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public int SkillId { get; set; }

        public IActionResult OnGet(int id)
        {
            SkillId = id;
            return Page();
        }

        [BindProperty]
        public SkillWebsiteTable SkillWebsiteTable { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                SkillId = SkillWebsiteTable.SkillId;
                return Page();
            }

            _context.SkillWebsiteTables.Add(SkillWebsiteTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = SkillWebsiteTable.SkillId });
        }
    }
}
