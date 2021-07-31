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

        public string currentFilter { get; set; }
        public string currentprim { get; set; }
        public string currentfinal { get; set; }

        public async Task<IActionResult> OnGetAsync(string duplicate, string search, string prim, string final)
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
                .Include(t => t.TblEmployeeRequestPrimaryInformations)
                .OrderBy(a => a.TblEmployeeRequestPageTimeLogs.Where(a => a.FldEmployeeRequestPageTimeLogPageLevel == "Level1").FirstOrDefault())
                .ToListAsync();

            currentFilter = search;
            currentprim = prim;
            currentfinal = final;

            //duplicate
            if (!string.IsNullOrEmpty(duplicate))
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a =>
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationNationalCode==duplicate ||
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationPhoneNo==duplicate ||
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationPostalCode==duplicate)
                    .ToList();
            }

            //search
            if (!string.IsNullOrEmpty(search))
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a =>
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationFirstName.Contains(search) ||
                        a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationLastName.Contains(search))
                    .ToList();
            }

            //primary
            if (prim == "0")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestPrimaryAcceptionId == null || a.FldEmployeeRequestPrimaryAcceptionId == 1)
                    .ToList();

            }
            else if (prim == "1")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestPrimaryAcceptionId == 3)
                    .ToList();
            }
            else if (prim == "2")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestPrimaryAcceptionId == 2)
                    .ToList();
            }

            //final
            if (final == "0")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestFinalAcceptionId == null)
                    .ToList();

            }
            else if (final == "1")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestFinalAcceptionId == 1)
                    .ToList();
            }
            else if (final == "2")
            {
                TblEmployeeRequestEmployee = TblEmployeeRequestEmployee
                    .Where(a => a.FldEmployeeRequestFinalAcceptionId == 2)
                    .ToList();
            }

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
