using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.Panel
{
    /// <summary>
    /// This is panel page of web application 
    /// </summary>

    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            ViewData["AllRegisteredUsers"] = _context.TblEmployeeRequestEmployees.Count();
            ViewData["MenRegisteredUsers"] = _context.TblEmployeeRequestPrimaryInformations.Where(a=>a.FldEmployeeRequestPrimaryInformationGender=="آقا").Count();
            ViewData["WomenRegisteredUsers"] = _context.TblEmployeeRequestPrimaryInformations.Where(a => a.FldEmployeeRequestPrimaryInformationGender == "خانم").Count();
            ViewData["AcceptedRegisteredUsers"] = _context.TblEmployeeRequestEmployees.Where(a=>a.FldEmployeeRequestFinalAcceptionId==1).Count();

            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");
        }
    }
}