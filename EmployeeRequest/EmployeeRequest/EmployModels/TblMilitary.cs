using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblMilitary
    {
        public TblMilitary()
        {
            TblUserMilitaries = new HashSet<TblUserMilitary>();
        }

        public int Id { get; set; }
        public string MilitaryStatus { get; set; }

        public virtual ICollection<TblUserMilitary> TblUserMilitaries { get; set; }
    }
}
