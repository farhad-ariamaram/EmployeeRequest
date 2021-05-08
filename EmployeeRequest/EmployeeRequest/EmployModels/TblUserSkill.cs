using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblUserSkill
    {
        public long Id { get; set; }
        public int? SkillId { get; set; }
        public string UserId { get; set; }
        public string SkillTitle { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }
        public string SkillType { get; set; }
        public int? SkillLevel { get; set; }
        public string LicenseNo { get; set; }
        public string LicenseReference { get; set; }
        public bool IsSelfTaught { get; set; }

        public virtual TblSkill Skill { get; set; }
        public virtual TblUser User { get; set; }
    }
}
