using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblUserMilitary
    {
        public long Id { get; set; }
        public int? MilitaryId { get; set; }
        public string UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? OrganizationId { get; set; }
        public string City { get; set; }
        public string Unit { get; set; }
        public string ExemptDescription { get; set; }
        public string Description { get; set; }

        public virtual TblMilitary Military { get; set; }
        public virtual TblMilitaryOrganization Organization { get; set; }
        public virtual TblUser User { get; set; }
    }
}
