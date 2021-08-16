using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.OutlineVersionPage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public long VersionId { get; set; }

        public IActionResult OnGet(long? id)
        {
            if (id.HasValue)
            {
                VersionId = id.Value;
                ViewData["OutlineId"] = new SelectList(_context.Outlines, "Id", "Id");
                ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id");
            }
            else
            {
                ViewData["OutlineId"] = new SelectList(_context.Outlines, "Id", "Id");
                ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id");
                ViewData["VersionId"] = new SelectList(_context.Versions.Where(a => a.Id == id.Value), "Id", "Id");
            }
            
            return Page();
        }

        [BindProperty]
        public OutlineVersion OutlineVersion { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OutlineVersions.Add(OutlineVersion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
