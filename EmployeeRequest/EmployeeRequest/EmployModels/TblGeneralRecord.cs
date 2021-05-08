using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblGeneralRecord
    {
        public long Id { get; set; }
        public string CriminalTiltle { get; set; }
        public string CriminalDes { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }

        public virtual TblUser User { get; set; }
    }
}
