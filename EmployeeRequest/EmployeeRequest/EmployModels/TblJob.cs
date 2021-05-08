using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblJob
    {
        public TblJob()
        {
            TblUserJobs = new HashSet<TblUserJob>();
        }

        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public string JobTitle { get; set; }
        public bool NeedMan { get; set; }
        public bool NeedWoman { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblUserJob> TblUserJobs { get; set; }
    }
}
