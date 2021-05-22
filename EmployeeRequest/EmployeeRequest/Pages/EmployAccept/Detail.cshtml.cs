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
    public class DetailModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public DetailModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public TblEmployeeRequestEmployee TblEmployeeRequestEmployee { get; set; }

        public TblEmployeeRequestUserSetting TblEmployeeRequestUserSetting { get; set; }

        public List<TblEmployeeRequestUserLanguage> TblEmployeeRequestUserLanguage { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            TblEmployeeRequestUserLanguage = _context.TblEmployeeRequestUserLanguages.Where(a=>a.FldEmployeeRequestEmployeeId == id).Include(t=>t.FldEmployeeRequestUserLanguageLanguageType).ToList();

            TblEmployeeRequestUserSetting = _context.TblEmployeeRequestUserSettings.Where(a => a.FldEmployeeRequestUserId == Int64.Parse(uid)).FirstOrDefault();

            TblEmployeeRequestEmployee = await _context.TblEmployeeRequestEmployees
                .Include(t => t.TblEmployeeRequestPrimaryInformations)

                .Include(t => t.TblCustomerDegrees).ThenInclude(t => t.Diploma)
                .Include(t => t.TblCustomerDegrees).ThenInclude(t => t.Education)

                .Include(t => t.TblEmployeeRequestEmergencyCalls)

                .Include(t => t.TblEmployeeRequestHowFinds)

                .Include(t => t.TblEmployeeRequestMedicalRecords)

                .Include(t => t.TblEmployeeRequestGeneralRecords)

                .Include(t => t.TblEmployeeRequestUserCompilations).ThenInclude(t => t.FldEmployeeRequestCompilationType)

                .Include(t => t.TblEmployeeRequestUserCreativities)

                .Include(t => t.TblEmployeeRequestUserCreativities).ThenInclude(t => t.FldEmployeeRequestCreativityType)

                .Include(t => t.TblEmployeeRequestUserJobs).ThenInclude(t => t.FldEmployeeRequestJobs)

                .Include(t => t.TblEmployeeRequestUserMilitaries).ThenInclude(t => t.FldEmployeeRequestMilitary)
                .Include(t => t.TblEmployeeRequestUserMilitaries).ThenInclude(t => t.FldEmployeeRequestMilitaryOrganization)

                .Include(t => t.TblEmployeeRequestUserSkills)

                .Include(t=>t.TblEmployeeRequestUserLanguages).ThenInclude(t=>t.FldEmployeeRequestUserLanguageLanguageType)

                .Include(t => t.TblWorkExperiences).ThenInclude(t => t.FldTaminJob)
                .Include(t => t.TblWorkExperiences).ThenInclude(t => t.TblWorkExperienceLeaveJobDtls).ThenInclude(t=>t.FldLeaveJobNavigation)
                
                .Where(m => m.FldEmployeeRequestEmployeeId == id)
                
                .FirstOrDefaultAsync();

            if (TblEmployeeRequestEmployee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnGetUpdate(bool green , bool red, bool openall)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            TblEmployeeRequestUserSetting = _context.TblEmployeeRequestUserSettings.Where(a => a.FldEmployeeRequestUserId == Int64.Parse(uid)).FirstOrDefault();


            TblEmployeeRequestUserSetting.FldEmployeeRequestUserSettingIsShowGreen = green;
            TblEmployeeRequestUserSetting.FldEmployeeRequestUserSettingIsShowRed = red;
            TblEmployeeRequestUserSetting.FldEmployeeRequestUserSettingIsCollaps = openall;

            _context.Update(TblEmployeeRequestUserSetting);

            _context.SaveChanges();

            return RedirectToPage("Index");

        }
    }
}
