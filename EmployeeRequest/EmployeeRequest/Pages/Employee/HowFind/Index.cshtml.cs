﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.Employee.HowFind
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblEmployeeRequestHowFind> TblEmployeeRequestHowFind { get;set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../../Index");
            }

            if (id == null)
            {
                return RedirectToPage("../../Index");
            }

            TblEmployeeRequestHowFind = await _context.TblEmployeeRequestHowFinds
                .Where(a=>a.FldEmployeeRequestEmployeeId==id)
                .Include(t => t.FldEmployeeRequestEmployee).ThenInclude(t=>t.TblEmployeeRequestPrimaryInformations).ToListAsync();

            return Page();
        }
    }
}
