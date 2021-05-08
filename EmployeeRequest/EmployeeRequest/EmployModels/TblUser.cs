using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.EmployModels
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblCustomerDegrees = new HashSet<TblCustomerDegree>();
            TblEmergencyCalls = new HashSet<TblEmergencyCall>();
            TblGeneralRecords = new HashSet<TblGeneralRecord>();
            TblHowFinds = new HashSet<TblHowFind>();
            TblIpLogs = new HashSet<TblIpLog>();
            TblMedicalRecords = new HashSet<TblMedicalRecord>();
            TblPageTimeLogs = new HashSet<TblPageTimeLog>();
            TblPrimaryInformations = new HashSet<TblPrimaryInformation>();
            TblUserCompilations = new HashSet<TblUserCompilation>();
            TblUserCreativities = new HashSet<TblUserCreativity>();
            TblUserJobs = new HashSet<TblUserJob>();
            TblUserLanguages = new HashSet<TblUserLanguage>();
            TblUserMilitaries = new HashSet<TblUserMilitary>();
            TblUserSkills = new HashSet<TblUserSkill>();
            TblWorkExperiences = new HashSet<TblWorkExperience>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CurrentLevel { get; set; }
        public long? PagesSequenceId { get; set; }

        public virtual TblPagesSequence PagesSequence { get; set; }
        public virtual ICollection<TblCustomerDegree> TblCustomerDegrees { get; set; }
        public virtual ICollection<TblEmergencyCall> TblEmergencyCalls { get; set; }
        public virtual ICollection<TblGeneralRecord> TblGeneralRecords { get; set; }
        public virtual ICollection<TblHowFind> TblHowFinds { get; set; }
        public virtual ICollection<TblIpLog> TblIpLogs { get; set; }
        public virtual ICollection<TblMedicalRecord> TblMedicalRecords { get; set; }
        public virtual ICollection<TblPageTimeLog> TblPageTimeLogs { get; set; }
        public virtual ICollection<TblPrimaryInformation> TblPrimaryInformations { get; set; }
        public virtual ICollection<TblUserCompilation> TblUserCompilations { get; set; }
        public virtual ICollection<TblUserCreativity> TblUserCreativities { get; set; }
        public virtual ICollection<TblUserJob> TblUserJobs { get; set; }
        public virtual ICollection<TblUserLanguage> TblUserLanguages { get; set; }
        public virtual ICollection<TblUserMilitary> TblUserMilitaries { get; set; }
        public virtual ICollection<TblUserSkill> TblUserSkills { get; set; }
        public virtual ICollection<TblWorkExperience> TblWorkExperiences { get; set; }
    }
}
