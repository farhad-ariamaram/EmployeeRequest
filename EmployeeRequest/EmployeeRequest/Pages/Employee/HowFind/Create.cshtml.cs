using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.HowFind
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public CreateModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            ViewData["EmployeeId"] = id;
            return Page();
        }

        [BindProperty]
        public TblEmployeeRequestHowFind TblEmployeeRequestHowFind { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            long lastid = _context.TblEmployeeRequestHowFinds.OrderByDescending(a => a.FldEmployeeRequestHowFindId).FirstOrDefault().FldEmployeeRequestHowFindId;

            TblEmployeeRequestHowFind.FldEmployeeRequestHowFindId = lastid + 1;

            _context.TblEmployeeRequestHowFinds.Add(TblEmployeeRequestHowFind);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index" , new {id = TblEmployeeRequestHowFind.FldEmployeeRequestEmployeeId });
        }
    }
}
