using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediatR;


namespace KetCRM.Application.StudentInfoBl.Commands.CreateStudentInfo;

public class CreateStudentInfoCommand : IRequest<int>
{
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
    [Required]
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
