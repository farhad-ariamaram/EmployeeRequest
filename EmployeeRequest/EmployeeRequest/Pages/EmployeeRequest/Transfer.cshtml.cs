using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.EmployModels;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.EmployeeRequest
{
    public class TransferModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;
        private readonly EmployDBContext _employContext;

        public TransferModel(EmployeeRequestDBContext context, EmployDBContext employContext)
        {
            _context = context;
            _employContext = employContext;
        }

        public IList<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequest { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestEmployeeRequest = await _context.TblEmployeeRequestEmployeeRequests
                .Include(t => t.FldEmployeeRequestJobOnet)
                .Include(t => t.FldEmployeeRequestJobTamin)
                .Include(t => t.FldEmployeeRequestJobs)
                .Include(t => t.FldEmployeeRequestUserAccepter)
                .Include(t => t.FldEmployeeRequestUserApplicant)
                .Include(t => t.FldEmployeeRequestUserSubmitter)
                .Include(t => t.FldEmployeeRequestJobTitleFrom)
                .ToListAsync();

            return Page();
        }

        public IActionResult OnGetTransfer(long id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }
            TblEmployeeRequestEmployeeRequest TblEmployeeRequestEmployeeRequest2 = _context.TblEmployeeRequestEmployeeRequests
                .Include(t => t.FldEmployeeRequestJobs)
                .Include(t => t.FldEmployeeRequestJobOnet)
                .Include(t => t.FldEmployeeRequestJobTamin)
                .Where(a => a.FldEmployeeRequestEmployeeRequestId == id)
                .FirstOrDefault();
            if (TblEmployeeRequestEmployeeRequest2 != null)
            {
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestIsTransfered = true;
                TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestTransferDate = DateTime.Now;
                _context.TblEmployeeRequestEmployeeRequests.Update(TblEmployeeRequestEmployeeRequest2);
                _context.SaveChanges();

                //TODO: Publish process here
                string jobTitleFrom = null;
                if (TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestJobTitleFromId == 1)
                {
                    jobTitleFrom = TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestJobs.JobsName;
                }
                else if (TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestJobTitleFromId == 2)
                {
                    jobTitleFrom = TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestJobTamin.FldTaminJobName;
                }
                else
                {
                    jobTitleFrom = TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestJobOnet.FldJobName;
                }
                EmployModels.TblJob newJob = new EmployModels.TblJob()
                {
                    JobTitle = jobTitleFrom,
                    IsActive = true,
                    StartDate = TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestStartDate,
                    EndDate = TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestEndDate,
                    NeedMan = TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestNeedMan,
                    NeedWoman = TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestNeedWoman,
                    Description = TblEmployeeRequestEmployeeRequest2.FldEmployeeRequestEmployeeRequestJobDescription
                };
                _employContext.TblJobs.Add(newJob);
                _employContext.SaveChanges();
            }
            return RedirectToPage("Index");
        }


    }
}