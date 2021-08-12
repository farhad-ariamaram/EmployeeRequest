using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class Log
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; }
    }
}
