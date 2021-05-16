using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.Employee.HowFind
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DeleteModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployeeRequestHowFind TblEmployeeRequestHowFind { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblEmployeeRequestHowFind = await _context.TblEmployeeRequestHowFinds
                .Include(t => t.FldEmployeeRequestEmployee).ThenInclude(t => t.TblEmployeeRequestPrimaryInformations).FirstOrDefaultAsync(m => m.FldEmployeeRequestHowFindId == id);

            if (TblEmployeeRequestHowFind == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblEmployeeRequestHowFind = await _context.TblEmployeeRequestHowFinds.FindAsync(id);

            if (TblEmployeeRequestHowFind != null)
            {
                _context.TblEmployeeRequestHowFinds.Remove(TblEmployeeRequestHowFind);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index", new { id = TblEmployeeRequestHowFind.FldEmployeeRequestEmployeeId });
        }
    }
}
