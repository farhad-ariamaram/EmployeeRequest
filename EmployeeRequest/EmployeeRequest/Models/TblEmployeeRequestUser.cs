using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestUser
    {
        public TblEmployeeRequestUser()
        {
            TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserAccepters = new HashSet<TblEmployeeRequestEmployeeRequest>();
            TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserApplicants = new HashSet<TblEmployeeRequestEmployeeRequest>();
            TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserSubmitters = new HashSet<TblEmployeeRequestEmployeeRequest>();
            TblEmployeeRequestInterviewSessions = new HashSet<TblEmployeeRequestInterviewSession>();
        }

        public long FldEmployeeRequestUserId { get; set; }
        public string FldEmployeeRequestUserUsername { get; set; }
        public string FldEmployeeRequestUserPassword { get; set; }

        public virtual ICollection<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserAccepters { get; set; }
        public virtual ICollection<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserApplicants { get; set; }
        public virtual ICollection<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserSubmitters { get; set; }
        public virtual ICollection<TblEmployeeRequestInterviewSession> TblEmployeeRequestInterviewSessions { get; set; }
    }
}
