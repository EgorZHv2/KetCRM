using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class StudentInfo
    {
        public int Id { get; set; }
        public int? StudiedLanguageId { get; set; }
        public bool? Dormitory { get; set; }
        public int? GroupId { get; set; }
        public bool? HasTwo { get; set; }
        public string? SchoolCertificateNumber { get; set; }
        public string? YearOfReleaseFromSchool { get; set; }
        public bool? HasMedal { get; set; }
        public string? GraduatedSchool { get; set; }
        public int? SchoolTypeId { get; set; }
        public bool? OnABudget { get; set; }
        public bool? TargetedEducation { get; set; }
        public int PersonId { get; set; }
        public int? SchoolEducationTypeId { get; set; }
        public string? OlimpiadeWinner { get; set; }
        public string? WorkExperience { get; set; }
        public int? StudentStatusId { get; set; }
        public string? StudentCerteficateNumber { get; set; }
        public string? StudentCardNumber { get; set; }
        public string? StudentRecordBookNumber { get; set; }
        public string? PassCardNumber { get; set; }
        public bool? NeedIssuePassCard { get; set; }

        public virtual Group? Group { get; set; }
        public virtual Person? Person { get; set; }
        public virtual SchoolEducationType? SchoolEducationType { get; set; }
        public virtual SchoolType? SchoolType { get; set; }
        public virtual StudentStatus? StudentStatus { get; set; }
        public virtual StudiedLanguage? StudiedLanguage { get; set; }
    }
}
