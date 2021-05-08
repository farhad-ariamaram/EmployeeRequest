using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblMedicalRecord
    {
        public long Id { get; set; }
        public bool HasProblem { get; set; }
        public string ProblemDes { get; set; }
        public bool IsAddict { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Disease { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool HasComplications { get; set; }
        public string ComplicationsDes { get; set; }

        public virtual TblUser User { get; set; }
    }
}
