using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblEmergencyCall
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relative { get; set; }
        public string PhoneNo { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public virtual TblUser User { get; set; }
    }
}
