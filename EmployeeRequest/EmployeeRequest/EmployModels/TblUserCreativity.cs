using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblUserCreativity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int? CreativityTypeId { get; set; }
        public string Explanation { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string LicenseNo { get; set; }
        public string LicenseReference { get; set; }

        public virtual TblCreativityType CreativityType { get; set; }
        public virtual TblUser User { get; set; }
    }
}
