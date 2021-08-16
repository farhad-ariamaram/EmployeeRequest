using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.TopicPage
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["VersionId"] = new SelectList(_context.Versions, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Topic Topic { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Topics.Add(Topic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
