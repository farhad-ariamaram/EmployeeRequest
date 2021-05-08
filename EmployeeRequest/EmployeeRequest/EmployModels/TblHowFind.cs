using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblHowFind
    {
        public long Id { get; set; }
        public string HowFindTitle { get; set; }
        public string AdditionalDes { get; set; }
        public string UserId { get; set; }

        public virtual TblUser User { get; set; }
    }
}
