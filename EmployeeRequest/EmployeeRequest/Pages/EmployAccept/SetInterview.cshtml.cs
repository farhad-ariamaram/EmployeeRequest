using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using EmployeeRequest.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.EmployAccept
{
    public class SetInterviewModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public SetInterviewModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestEmployee TblEmployeeRequestEmployee { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .FirstOrDefaultAsync(m => m.FldEmployeeRequestEmployeeId == id);

            if (TblEmployeeRequestEmployee == null)
            {
                return NotFound();
            }

            ViewData["startdate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate.toPersianDate() + ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate).TimeOfDay;
            ViewData["enddate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate.toPersianDate() + ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate).TimeOfDay;

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblEmployeeRequestEmployee).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}