﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblSmsReceived
    {
        public long Id { get; set; }
        public string Phone { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; }
        public bool? IsVisit { get; set; }
    }
}
