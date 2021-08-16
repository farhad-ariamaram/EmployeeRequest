using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRequest.Models;

namespace EmployeeRequest.Pages.EmployeeRequest.SkillPage
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public IndexModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IList<TblEmployeeRequestSkill> TblEmployeeRequestSkill { get;set; }

        public async Task OnGetAsync()
        {
            TblEmployeeRequestSkill = await _context.TblEmployeeRequestSkills.ToListAsync();
        }
    }
}
