using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EmployeeRequest.Pages
{
    public class IndexModel : PageModel
    {
        EmployeeRequestDBContext _db;

        public IndexModel(EmployeeRequestDBContext db)
        {
            _db = db;
        }

        public TblJobTamin TblJobTamin { get; set; }

        public void OnGet()
        {
            TblJobTamin = _db.TblJobTamins.Find(7);
        }
    }
}
