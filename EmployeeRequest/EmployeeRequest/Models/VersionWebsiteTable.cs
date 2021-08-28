using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class VersionWebsiteTable
    {
        public int Id { get; set; }
        public string VersionWebsite { get; set; }
        public string EducationalWebsite { get; set; }
        public string QuestionalWebsite { get; set; }
        public long VersionId { get; set; }

        public virtual Version Version { get; set; }
    }
}
