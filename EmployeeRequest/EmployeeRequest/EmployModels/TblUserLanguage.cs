using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblUserLanguage
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public int? LanguageTypeId { get; set; }
        public int? ReadingLevel { get; set; }
        public int? WritingLevel { get; set; }
        public int? ListeningLevel { get; set; }
        public int? SpeakingLevel { get; set; }
        public string Description { get; set; }
        public bool IsNative { get; set; }

        public virtual TblLanguageType LanguageType { get; set; }
        public virtual TblUser User { get; set; }
    }
}
