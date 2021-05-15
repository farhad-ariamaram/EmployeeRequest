using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRequest.Models;
using EmployeeRequest.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequest.Pages.EmployAccept
{
    public class SearchModel : PageModel
    {
        private readonly EmployeeRequestDBContext _context;

        public SearchModel(EmployeeRequestDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            string uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnGetSearchAsync()
        {
            return new JsonResult(new { data = _context.TblEmployeeRequestEmployees.Include(a => a.TblEmployeeRequestPrimaryInformations).Select(a => new { a.FldEmployeeRequestEmployeeId, a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationFirstName, a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationLastName, a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationNationalCode, a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationPhoneNo }).ToList() });
        }

        public async Task<IActionResult> OnGetFilterSearchAsync(bool active_gender, string gender,
                                                                bool active_child, string childNo,
                                                                bool active_marital, string marital,
                                                                bool active_tutelage, string tutelage,
                                                                bool active_birthdate, DateTime birthDate,
                                                                bool active_degree, string degree,
                                                                bool active_degreeField, string degreeField,
                                                                bool active_compile,
                                                                bool active_general,
                                                                bool active_medical,
                                                                bool active_addict)
        {
            var result = _context.TblEmployeeRequestEmployees
                .Include(a => a.TblEmployeeRequestPrimaryInformations)
                .Include(a => a.TblCustomerDegrees).ThenInclude(a=>a.Diploma)
                .Include(a => a.TblEmployeeRequestUserCompilations)
                .Include(a => a.TblEmployeeRequestGeneralRecords)
                .Include(a => a.TblEmployeeRequestMedicalRecords)
                .Where(_ => true);

            #region Based On Primary Informations
            if (active_gender)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationGender == gender);
            }

            if (active_child)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationChildrenNo == int.Parse(childNo));
            }

            if (active_marital)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationMarital == marital);
            }

            if (active_tutelage)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationTutelage == int.Parse(tutelage));
            }

            if (active_birthdate)
            {
                result = result.Where(a => a.TblEmployeeRequestPrimaryInformations.FirstOrDefault().FldEmployeeRequestPrimaryInformationBirthDate >= birthDate);
            }
            #endregion

            #region Based On Degree
            if (active_degree)
            {
                result = result.Where(a => a.TblCustomerDegrees.Any(a => a.DiplomaId == int.Parse(degree)));
            }

            if (active_degreeField)
            {
                result = result.Where(a => a.TblCustomerDegrees.Any(a => a.FldEducationName.Contains(degreeField)));
            }
            #endregion

            #region Based On Compilations
            if (active_compile)
            {
                result = result.Where(a => a.TblEmployeeRequestUserCompilations.Any(a => a.FldEmployeeRequestUserCompilationTitle != null));
            }
            #endregion

            #region Based On GeneralRecords
            if (active_general)
            {
                result = result.Where(a => a.TblEmployeeRequestGeneralRecords.Any(a => a.FldEmployeeRequestGeneralRecordCriminalTiltle != null));
            }
            #endregion

            #region Based On Medical
            if (active_medical)
            {
                result = result.Where(a => a.TblEmployeeRequestMedicalRecords.All(a => a.FldEmployeeRequestMedicalRecordDisease == null));
            }
            if (active_addict)
            {
                result = result.Where(a => a.TblEmployeeRequestMedicalRecords.All(a => a.FldEmployeeRequestMedicalRecordIsAddict == false));
            }
            #endregion

            var finalResult = result.Select(a => new
            {
                a.FldEmployeeRequestEmployeeId,
                a.TblEmployeeRequestPrimaryInformations
                .FirstOrDefault().FldEmployeeRequestPrimaryInformationFirstName,
                a.TblEmployeeRequestPrimaryInformations
                .FirstOrDefault().FldEmployeeRequestPrimaryInformationLastName,
                a.TblEmployeeRequestPrimaryInformations
                .FirstOrDefault().FldEmployeeRequestPrimaryInformationNationalCode,
                a.TblEmployeeRequestPrimaryInformations
                .FirstOrDefault().FldEmployeeRequestPrimaryInformationPhoneNo
            }).ToList();

            return new JsonResult(new { data = finalResult });
        }
    }
}