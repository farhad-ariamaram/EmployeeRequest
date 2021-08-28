using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class SkillWebsiteTable
    {
        public int Id { get; set; }
        public string SkillWebsite { get; set; }
        public string EducationalWebsite { get; set; }
        public string QuestionalWebsite { get; set; }
        public int SkillId { get; set; }

        public virtual TblEmployeeRequestSkill Skill { get; set; }
    }
}
