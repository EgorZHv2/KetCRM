using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KetCRM.Application.Common.Mapping;
using KetCRM.Domain.Entities;

namespace KetCRM.Application.StudentInfoBl.Queries.GetStudentInfoList
{
    public class StudentInfoItemDto : IMapFrom<StudentInfo>
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
        public int? PersonId { get; set; }
        public int? SchoolEducationTypeId { get; set; }
        public string? OlimpiadeWinner { get; set; }
        public string? WorkExperience { get; set; }
        public int? StudentStatusId { get; set; }
        public string? StudentCerteficateNumber { get; set; }
        public string? StudentCardNumber { get; set; }
        public string? StudentRecordBookNumber { get; set; }
        public string? PassCardNumber { get; set; }
        public bool? NeedIssuePassCard { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentInfo, StudentInfoItemDto>()
                .ForMember(empDto => empDto.Id,
                opt => opt.MapFrom(emp => emp.Id))
                .ForMember(empDto => empDto.StudiedLanguageId,
                opt => opt.MapFrom(emp => emp.StudiedLanguageId))
                .ForMember(empDto => empDto.Dormitory,
                opt => opt.MapFrom(emp => emp.Dormitory))
                .ForMember(empDto => empDto.GroupId,
                opt => opt.MapFrom(emp => emp.GroupId))
                .ForMember(empDto => empDto.HasTwo,
                opt => opt.MapFrom(emp => emp.HasTwo))
                .ForMember(empDto => empDto.SchoolCertificateNumber,
                opt => opt.MapFrom(emp => emp.SchoolCertificateNumber))
                .ForMember(empDto => empDto.YearOfReleaseFromSchool,
                opt => opt.MapFrom(emp => emp.YearOfReleaseFromSchool))
                .ForMember(empDto => empDto.HasMedal,
                opt => opt.MapFrom(emp => emp.HasMedal))
                .ForMember(empDto => empDto.GraduatedSchool,
                opt => opt.MapFrom(emp => emp.GraduatedSchool))
                .ForMember(empDto => empDto.SchoolTypeId,
                opt => opt.MapFrom(emp => emp.SchoolTypeId))
                .ForMember(empDto => empDto.OnABudget,
                opt => opt.MapFrom(emp => emp.OnABudget))
                .ForMember(empDto => empDto.TargetedEducation,
                opt => opt.MapFrom(emp => emp.TargetedEducation))
                .ForMember(empDto => empDto.PersonId,
                opt => opt.MapFrom(emp => emp.PersonId))
                .ForMember(empDto => empDto.SchoolEducationTypeId,
                opt => opt.MapFrom(emp => emp.SchoolEducationTypeId))
                .ForMember(empDto => empDto.OlimpiadeWinner,
                opt => opt.MapFrom(emp => emp.OlimpiadeWinner))
                .ForMember(empDto => empDto.WorkExperience,
                opt => opt.MapFrom(emp => emp.WorkExperience))
                .ForMember(empDto => empDto.StudentStatusId,
                opt => opt.MapFrom(emp => emp.StudentStatusId))
                .ForMember(empDto => empDto.StudentCerteficateNumber,
                opt => opt.MapFrom(emp => emp.StudentCerteficateNumber))
                .ForMember(empDto => empDto.StudentCardNumber,
                opt => opt.MapFrom(emp => emp.StudentCardNumber))
                .ForMember(empDto => empDto.StudentRecordBookNumber,
                opt => opt.MapFrom(emp => emp.StudentRecordBookNumber))
                .ForMember(empDto => empDto.PassCardNumber,
                opt => opt.MapFrom(emp => emp.PassCardNumber))
                .ForMember(empDto => empDto.NeedIssuePassCard,
                opt => opt.MapFrom(emp => emp.NeedIssuePassCard));


        }
    }
}
