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
        ViewData["FldEmployeeRequestUserApplicantId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
        ViewData["FldEmployeeRequestUserSubmitterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["FldEmployeeRequestUserApplicantId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
                ViewData["FldEmployeeRequestUserSubmitterId"] = new SelectList(_context.TblEmployeeRequestUsers, "FldEmployeeRequestUserId", "FldEmployeeRequestUserUsername");
                return Page();
            }

            //TODO: use tamin and onet dropdowns for fields
            //TODO: persian datetime picker for datetime fields
            TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobTaminId = int.Parse(Request.Form["taminjobdropdown"].ToString());
            if (!string.IsNullOrEmpty(Request.Form["onetjobdropdown"].ToString()))
            {
                TblEmployeeRequestEmployeeRequest.FldEmployeeRequestJobOnetId = int.Parse(Request.Form["onetjobdropdown"].ToString());
            }
            _context.TblEmployeeRequestEmployeeRequests.Add(TblEmployeeRequestEmployeeRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetJobsAsync(string jobName)
        {
            return new JsonResult(_context.TblJobTamins.Where(a => a.FldTaminJobName.Contains(jobName) || a.FldTaminJobName.Contains(jobName.Replace("ی", "ي").Replace("ک", "ك"))).ToList());
        }

        public async Task<IActionResult> OnGetJobsoAsync(string jobName)
        {
            return new JsonResult(_context.TblJobs.Where(a => a.FldJobName.Contains(jobName) || a.FldJobName.Contains(jobName.Replace("ی", "ي").Replace("ک", "ك"))).ToList());
        }
    }
}
