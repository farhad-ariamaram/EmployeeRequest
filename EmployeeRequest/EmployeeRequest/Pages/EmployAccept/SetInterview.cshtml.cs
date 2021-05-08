using System;
using System.Collections.Generic;
using System.Globalization;
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

            ViewData["startdate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate.toPersianDate();
            ViewData["starttime"] = ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate).TimeOfDay;

            ViewData["enddate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate.toPersianDate();
            ViewData["endtime"] = ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate).TimeOfDay;

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["startdate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate.toPersianDate();
                ViewData["starttime"] = ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewStartDate).TimeOfDay;
                ViewData["enddate"] = TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate.toPersianDate();
                ViewData["endtime"] = ((DateTime)TblEmployeeRequestEmployee.FldEmployeeRequestEmployeeInterviewEndDate).TimeOfDay;
                return Page();
            }

            string startdate = Request.Form["startdate"] + "/" + Request.Form["starttime"];
            string enddate = Request.Form["enddate"] + "/" + Request.Form["endtime"];

            var startdatearray = startdate.Split('/');
            var starttimearray = startdatearray[3].Split(':');
            var enddatearray = startdate.Split('/');
            PersianCalendar pc = new PersianCalendar();

            DateTime startdatefinal = pc.ToDateTime(int.Parse(startdatearray[0]), int.Parse(startdatearray[1]), int.Parse(startdatearray[2]), int.Parse(starttimearray[0]), int.Parse(starttimearray[1]), int.Parse(starttimearray[2]),0);



            _context.Attach(TblEmployeeRequestEmployee).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}