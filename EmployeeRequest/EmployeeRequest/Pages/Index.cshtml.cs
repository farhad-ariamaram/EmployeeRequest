using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeRequest.Pages
{
    /// <summary>
    /// This is login page of web application 
    /// and all things start from here 
    /// </summary>

    public class IndexModel : PageModel
    {
        EmployeeRequestDBContext _db;

        public IndexModel(EmployeeRequestDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public LoginModel loginModel { get; set; }

        public IActionResult OnGet()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid != null)
            {
                return RedirectToPage("Panel/Index");
            } 

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var checkUser = _db.TblEmployeeRequestUsers
                .Where(a => a.FldEmployeeRequestUserUsername.Equals(loginModel.Username))
                .Where(a => a.FldEmployeeRequestUserPassword.Equals(loginModel.Password));

            if (!checkUser.Any())
            {
                ModelState.AddModelError("WrongUP", "نام کاربری یا کلمه عبور اشتباه است");
                return Page();
            }

            string uid = checkUser.FirstOrDefault().FldEmployeeRequestUserId.ToString();
            HttpContext.Session.SetString("uid", uid);

            return RedirectToPage("Panel/Index");
        }
    }

    public class LoginModel
    {
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        public string Username { get; set; }

        [DisplayName("کلمه عبور")]
        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        public string Password { get; set; }
    }
}