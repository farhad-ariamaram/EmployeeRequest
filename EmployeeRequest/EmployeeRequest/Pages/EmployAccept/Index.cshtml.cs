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
                .Include(t => t.FldEmployeeRequestUserPrimaryAccepter)
                .Include(t => t.TblEmployeeRequestPageTimeLogs)
                .OrderBy(a => a.TblEmployeeRequestPageTimeLogs.Where(a => a.FldEmployeeRequestPageTimeLogPageLevel == "Level1").FirstOrDefault())
                .ToListAsync();

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnGetStatusAsync(bool prim, bool final, bool noval, bool nprim , bool nfinal , bool nnoval)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }


            var a = _context.TblEmployeeRequestEmployees
               .Include(t => t.FldEmployeeRequestFinalAcception)
               .Include(t => t.FldEmployeeRequestPagesSequence)
               .Include(t => t.FldEmployeeRequestPrimaryAcception)
               .Include(t => t.FldEmployeeRequestUserFinalAccepter)
               .Include(t => t.FldEmployeeRequestUserPrimaryAccepter)
               .Include(t => t.TblEmployeeRequestPageTimeLogs)
               .Where(t => true);

            if (prim)
            {
                a = a.Where(b=>b.FldEmployeeRequestPrimaryAcceptionId == 3);
            }

            if (final)
            {
                a = a.Where(b => b.FldEmployeeRequestFinalAcceptionId == 1);
            }

            if (noval)
            {
                a = a.Where(b => b.FldEmployeeRequestPrimaryAcceptionId == null || b.FldEmployeeRequestPrimaryAcceptionId == 1);
            }

            if (nprim)
            {
                a = a.Where(b => b.FldEmployeeRequestPrimaryAcceptionId == 2);
            }

            if (nfinal)
            {
                a = a.Where(b => b.FldEmployeeRequestFinalAcceptionId == 2);
            }

            if (nnoval)
            {
                a = a.Where(b => b.FldEmployeeRequestPrimaryAcceptionId != null && b.FldEmployeeRequestPrimaryAcceptionId != 1);
            }

            TblEmployeeRequestEmployee = a.OrderBy(a => a.TblEmployeeRequestPageTimeLogs.Where(a => a.FldEmployeeRequestPageTimeLogPageLevel == "Level1").FirstOrDefault()).ToList();

            TblEmployeeRequestPrimaryInformation = await _context.TblEmployeeRequestPrimaryInformations.ToListAsync();

            return Page();
        }

        public IActionResult OnGetAccept(string id, string description)
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
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptDescription = description;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetDeny(string id, string description)
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
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryRejectDescription = description;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetFAccept(string id, string description)
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
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptDescription = description;
                _context.TblEmployeeRequestEmployees.Update(TblEmployeeRequestEmployee2);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetFDeny(string id, string description)
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
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalRejectDescription = description;
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
                .Include(t => t.FldEmployeeRequestUserPrimaryAccepter)
                .Include(t => t.TblEmployeeRequestPageTimeLogs)
                .OrderBy(a => a.TblEmployeeRequestPageTimeLogs.Where(a => a.FldEmployeeRequestPageTimeLogPageLevel == "Level1").FirstOrDefault())
                .ToListAsync();

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
                .Include(t => t.FldEmployeeRequestUserPrimaryAccepter)
                .Include(t => t.TblEmployeeRequestPageTimeLogs)
                .OrderBy(a => a.TblEmployeeRequestPageTimeLogs.Where(a => a.FldEmployeeRequestPageTimeLogPageLevel == "Level1").FirstOrDefault())
                .ToListAsync();

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
                .Include(t => t.FldEmployeeRequestUserPrimaryAccepter)
                .Include(t => t.TblEmployeeRequestPageTimeLogs)
                .OrderBy(a => a.TblEmployeeRequestPageTimeLogs.Where(a => a.FldEmployeeRequestPageTimeLogPageLevel == "Level1").FirstOrDefault())
                .ToListAsync();

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
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalRejectDescription = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeeFinalAcceptDescription = null;
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
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryAcceptDescription = null;
                TblEmployeeRequestEmployee2.FldEmployeeRequestEmployeePrimaryRejectDescription = null;
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
