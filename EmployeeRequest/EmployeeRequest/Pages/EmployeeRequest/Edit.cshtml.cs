using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public EditModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblEmployeeRequestEmployeeRequest = await _context.TblEmployeeRequestEmployeeRequests
                .Include(t => t.FldEmployeeRequestJobOnet)
                .Include(t => t.FldEmployeeRequestJobTamin)
                .Include(t => t.FldEmployeeRequestJobs)
                .Include(t => t.FldEmployeeRequestUserAccepter)
                .Include(t => t.FldEmployeeRequestUserApplicant)
                .Include(t => t.FldEmployeeRequestUserSubmitter).FirstOrDefaultAsync(m => m.FldEmployeeRequestEmployeeRequestId == id);

            if (TblEmployeeRequestEmployeeRequest == null)
            {
                return NotFound();
            }
           ViewData["FldEmployeeRequestJobOnetId"] = new SelectList(_context.TblJobs, "FldJobId", "FldJobName");
           ViewData["FldEmployeeRequestJobTaminId"] = new SelectList(_context.TblJobTamins, "FldTaminJobId", "FldTaminJobCode");
           ViewData["FldEmployeeRequestJobsId"] = new SelectList(_context.PayJobs, "JobsId", "JobsCode");
           ViewData["FldEmployeeRequestUserAccepterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserId");
           ViewData["FldEmployeeRequestUserApplicantId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserId");
           ViewData["FldEmployeeRequestUserSubmitterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserId");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblEmployeeRequestEmployeeRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeRequestEmployeeRequestExists(TblEmployeeRequestEmployeeRequest.FldEmployeeRequestEmployeeRequestId))
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

        private bool TblEmployeeRequestEmployeeRequestExists(long id)
        {
            return _context.TblEmployeeRequestEmployeeRequests.Any(e => e.FldEmployeeRequestEmployeeRequestId == id);
        }
    }
}
