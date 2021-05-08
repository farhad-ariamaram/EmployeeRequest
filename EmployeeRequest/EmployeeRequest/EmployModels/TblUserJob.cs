using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblUserJob
    {
        public long Id { get; set; }
        public string JobTitle { get; set; }
        public string UserId { get; set; }
        public int? JobsId { get; set; }
        public string Description { get; set; }
        public string RequestMoney { get; set; }
        public string WhatKnowAbout { get; set; }

        public virtual TblJob Jobs { get; set; }
        public virtual TblUser User { get; set; }
    }
}
