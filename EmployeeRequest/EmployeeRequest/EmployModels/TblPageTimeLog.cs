using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblPageTimeLog
    {
        public long Id { get; set; }
        public string PageLevel { get; set; }
        public string UserId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual TblUser User { get; set; }
    }
}
