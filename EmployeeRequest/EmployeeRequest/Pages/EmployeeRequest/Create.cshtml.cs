using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest
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
        //ViewData["FldEmployeeRequestJobOnetId"] = new SelectList(_context.TblJobs, "FldJobId", "FldJobName");
        //ViewData["FldEmployeeRequestJobTaminId"] = new SelectList(_context.TblJobTamins, "FldTaminJobId", "FldTaminJobCode");
        ViewData["FldEmployeeRequestUserAccepterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserId");
        ViewData["FldEmployeeRequestUserApplicantId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserId");
        ViewData["FldEmployeeRequestUserSubmitterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserId");
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //TODO: use tamin and onet dropdowns for fields
            //TODO: persian datetime picker for datetime fields
            _context.TblEmployeeRequestEmployeeRequests.Add(TblEmployeeRequestEmployeeRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetJobsAsync(string jobName)
        {
            return new JsonResult(_context.TblJobTamins.Where(a => a.FldTaminJobName.Contains(jobName)).ToList());
        }

        public async Task<IActionResult> OnGetJobsoAsync(string jobName)
        {
            return new JsonResult(_context.TblJobs.Where(a => a.FldJobName.Contains(jobName)).ToList());
        }
    }
}
