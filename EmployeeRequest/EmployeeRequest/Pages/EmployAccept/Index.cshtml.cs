using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployAccept
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblEmployeeRequestEmployee> TblEmployeeRequestEmployee { get; set; }
        public IList<TblEmployeeRequestPrimaryInformation> TblEmployeeRequestPrimaryInformation { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .Include(t => t.FldEmployeeRequestFinalAcception)
                .Include(t => t.FldEmployeeRequestPagesSequence)
                .Include(t => t.FldEmployeeRequestPrimaryAcception)
                .Include(t => t.FldEmployeeRequestUserFinalAccepter)
                .Include(t => t.FldEmployeeRequestUserPrimaryAccepter).ToListAsync();

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.ToListAsync();

            return Page();
        }

        public IActionResult OnGetAccept(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestPrimaryAcceptionId = 3;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserPrimaryAccepterId = Int64.Parse(uid);
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetDeny(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestPrimaryAcceptionId = 2;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserPrimaryAccepterId = Int64.Parse(uid);
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetFAccept(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestFinalAcceptionId = 1;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserFinalAccepterId = Int64.Parse(uid);
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetFDeny(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestFinalAcceptionId = 2;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptionDate = DateTime.Now;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserFinalAccepterId = Int64.Parse(uid);
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnGetFilterAcceptedAsync()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .Where(a => a.FldEmployeeRequestEmployeeFinalAcceptionDate != null)
                .Include(t => t.FldEmployeeRequestFinalAcception)
                .Include(t => t.FldEmployeeRequestPagesSequence)
                .Include(t => t.FldEmployeeRequestPrimaryAcception)
                .Include(t => t.FldEmployeeRequestUserFinalAccepter)
                .Include(t => t.FldEmployeeRequestUserPrimaryAccepter).ToListAsync();

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnGetFilterNotAcceptedAsync()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .Where(a => a.FldEmployeeRequestEmployeeFinalAcceptionDate == null)
                .Include(t => t.FldEmployeeRequestFinalAcception)
                .Include(t => t.FldEmployeeRequestPagesSequence)
                .Include(t => t.FldEmployeeRequestPrimaryAcception)
                .Include(t => t.FldEmployeeRequestUserFinalAccepter)
                .Include(t => t.FldEmployeeRequestUserPrimaryAccepter).ToListAsync();

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnGetFilterAllAsync()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .Include(t => t.FldEmployeeRequestFinalAcception)
                .Include(t => t.FldEmployeeRequestPagesSequence)
                .Include(t => t.FldEmployeeRequestPrimaryAcception)
                .Include(t => t.FldEmployeeRequestUserFinalAccepter)
                .Include(t => t.FldEmployeeRequestUserPrimaryAccepter).ToListAsync();

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.ToListAsync();

            return Page();
        }

        public IActionResult OnGetFRevert(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestFinalAcceptionId = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptionDate = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserFinalAccepterId = null;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }


        public IActionResult OnGetRevert(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestPrimaryAcceptionId = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptionDate = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestUserPrimaryAccepterId = null;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetIRevert(string id)
        {
            TblEmployeeRequestEmployee TblEmployeeRequestEmployee2 = _context.TblEmployeeRequestEmployees.Find(id);
            if (TblEmployeeRequestEmployee2 != null)
            {
                string uid = HttpContext.Session.GetString("uid");
                if (uid == null)
                {
                    return RedirectToPage("../Index");
                }
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeInterviewEndDate = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeInterviewStartDate = null;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

    }
}
