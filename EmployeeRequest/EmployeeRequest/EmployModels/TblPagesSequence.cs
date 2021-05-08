using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblPagesSequence
    {
        public TblPagesSequence()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public long Id { get; set; }
        public bool? Status { get; set; }
        public long? Record { get; set; }
        public int? One { get; set; }
        public int? Two { get; set; }
        public int? Three { get; set; }
        public int? Four { get; set; }
        public int? Five { get; set; }
        public int? Six { get; set; }
        public int? Seven { get; set; }
        public int? Eight { get; set; }
        public int? Nine { get; set; }
        public int? Ten { get; set; }
        public int? Eleven { get; set; }
        public int? Twelve { get; set; }
        public int? Thirteen { get; set; }
        public int? Fourteen { get; set; }
        public int? Fifteen { get; set; }
        public int? Sixteen { get; set; }

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
