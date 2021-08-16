﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.OutlineVersionPage
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OutlineVersion OutlineVersion { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OutlineVersion = await _context.OutlineVersions
                .Include(o => o.Outline)
                .Include(o => o.Topic)
                .Include(o => o.Version).FirstOrDefaultAsync(m => m.Id == id);

            if (OutlineVersion == null)
            {
                return NotFound();
            }
           ViewData["OutlineId"] = new SelectList(_context.Outlines, "Id", "Id");
           ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id");
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

            _context.Attach(OutlineVersion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutlineVersionExists(OutlineVersion.Id))
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

        private bool OutlineVersionExists(long id)
        {
            return _context.OutlineVersions.Any(e => e.Id == id);
        }
    }
}
