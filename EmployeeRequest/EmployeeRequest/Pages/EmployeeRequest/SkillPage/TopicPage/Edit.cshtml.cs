using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.TopicPage
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Topic Topic { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topic = await _context.Topics
                .Include(t => t.Version).FirstOrDefaultAsync(m => m.Id == id);

            if (Topic == null)
            {
                return NotFound();
            }
           ViewData["VersionId"] = new SelectList(_context.Versions, "Id", "Id");
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

            _context.Attach(Topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(Topic.Id))
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

        private bool TopicExists(long id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }
    }
}
