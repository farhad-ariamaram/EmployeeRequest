using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage.SkillWebsiteTablePage
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<SkillWebsiteTable> SkillWebsiteTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            ViewData["id"] = id;
            SkillWebsiteTable = await _context.SkillWebsiteTables
                .Where(a => a.SkillId == id)
                .Include(s => s.Skill).ToListAsync();

            return Page();
        }
    }
}
