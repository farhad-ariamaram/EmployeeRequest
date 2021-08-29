﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRequest.Models
{
    public class TblEmployeeRequestSkillMD
    {
        [RegularExpression(@"^.{1,100}$",ErrorMessage ="طول فیلد حداکثر 100 کاراکتر میباشد")]
        [Required(ErrorMessage = "فیلد اجباری می‌باشد")]
        public string FldEmployeeRequestSkillsSkillTitle { get; set; }

        [RegularExpression(@"^.{1,100}$", ErrorMessage = "طول فیلد حداکثر 100 کاراکتر میباشد")]
        [Required(ErrorMessage = "فیلد اجباری می‌باشد")]
        public string FldEmployeeRequestSkillsSkillEnglishTitle { get; set; }

        [RegularExpression(@"^.{1,2000}$", ErrorMessage = "طول فیلد حداکثر 2000 کاراکتر میباشد")]
        public string FldEmployeeRequestSkillsSkillDescription { get; set; }

        [RegularExpression(@"^.{1,2000}$", ErrorMessage = "طول فیلد حداکثر 2000 کاراکتر میباشد")]
        public string FldEmployeeRequestSkillsSkillEnglishDescription { get; set; }
    }

    [ModelMetadataType(typeof(TblEmployeeRequestSkillMD))]
    public partial class TblEmployeeRequestSkill
    {
    }
}
