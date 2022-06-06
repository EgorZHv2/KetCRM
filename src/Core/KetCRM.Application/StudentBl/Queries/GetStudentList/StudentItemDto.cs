using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.StudentBl.Queries.GetStudentList
{
    public class StudentItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? PersonType { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SNILS { get; set; }
        public string? InsuranceNumber { get; set; }
        public string? PassportSeries { get; set; }
        public string? PassportNumber { get; set; }
        public DateTime? PassportDate { get; set; }
        public string? PassportPlace { get; set; }
        public string? Comment { get; set; }
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
        public int? WorkExperience { get; set; }
        public int? StudentStatusId { get; set; }
        public string? StudentCerteficateNumber { get; set; }
        public string? StudentCardNumber { get; set; }
        public string? StudentRecordBookNumber { get; set; }
        public string? PassCardNumber { get; set; }
        public bool? NeedIssuePassCard { get; set; }
    }
}
