using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.Models
{
    public class CreateStudentModel
    {
        public string Name { get; set; }
        public string Suranme { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PassportSeries { get; set; }
        public string? PassportNumber { get; set; }
        public int? PersonType { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Snils { get; set; }
        public string? InsurensNumber { get; set; }
        public DateTime? PassportDate { get; set; }
        public string? PassportPlace { get; set; }
        public string? Comment { get; set; }
        public int? GroupId { get; set; }
        public int? StudentLanguageId { get; set; }
        public bool? Dormitory { get; set; }
        public bool? HasTwo { get; set; }
        public string? StudentCerteficateNumber { get; set; }
        public string? YearOfReleaseFromSchool { get; set; }
        public bool? HasMedal { get; set; }
        public string? GraduatedSchool { get; set; }
        public int? SchoolTypeId { get; set; }
        public bool? OnABudget { get; set; }
        public bool? TargetedEducation { get; set; }
        public string? OlimpiadeWinner { get; set; }
        public string? WorkExperience { get; set; }
        public int? StudentStatusId { get; set; }
        public string? SchoolCertificateNumber { get; set; }
        public string? StudentCardNumber { get; set; }
        public string? StudentRecordBookNumber { get; set; }
        public string? PassCardNumber { get; set; }
        public bool? NeedIssuePassCard { get; set; }
        public int SchoolEducationTypeId { get; set; }
        public byte[]? Photo { get; set; }
    }
}
