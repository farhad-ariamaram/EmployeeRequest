using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblUserCompilation
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public int? CompilationTypeId { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public DateTime? Date { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public virtual TblCompilationType CompilationType { get; set; }
        public virtual TblUser User { get; set; }
    }
}
