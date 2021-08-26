using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRequest.Models
{
    public class TblEmployeeRequestSkillMD
    {
        [StringLength(100, ErrorMessage = "طول فیلد حداکثر 100 کاراکتر می‌باشد")]
        [Required(ErrorMessage = "فیلد اجباری می‌باشد")]
        public string FldEmployeeRequestSkillsSkillTitle { get; set; }

        [StringLength(100, ErrorMessage = "طول فیلد حداکثر 100 کاراکتر می‌باشد")]
        [Required(ErrorMessage = "فیلد اجباری می‌باشد")]
        public string FldEmployeeRequestSkillsSkillEnglishTitle { get; set; }

        [StringLength(2000,MinimumLength =10, ErrorMessage = "طول فیلد حداکثر 2000 کاراکتر می‌باشد")]
        public string FldEmployeeRequestSkillsSkillDescription { get; set; }

        [StringLength(2000, ErrorMessage = "طول فیلد حداکثر 2000 کاراکتر می‌باشد")]
        public string FldEmployeeRequestSkillsSkillEnglishDescription { get; set; }
    }

    [ModelMetadataType(typeof(TblEmployeeRequestSkillMD))]
    public partial class TblEmployeeRequestSkill
    {
    }
}
