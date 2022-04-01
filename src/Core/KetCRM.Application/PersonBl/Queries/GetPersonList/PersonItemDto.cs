using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetCRM.Application.Common.Mapping;
using AutoMapper;
using KetCRM.Domain.Entities;

namespace KetCRM.Application.PersonBl.Queries.GetPersonList
{
    public class PersonItemDto :IMapFrom<Person>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonItemDto>()
                .ForMember(empDto => empDto.Id,
                opt => opt.MapFrom(emp => emp.Id))
                .ForMember(empDto => empDto.Name,
                opt => opt.MapFrom(emp => emp.Name))
                .ForMember(empDto => empDto.Surname,
                opt => opt.MapFrom(emp => emp.Surname))
                .ForMember(empDto => empDto.Patronymic,
                opt => opt.MapFrom(emp => emp.Patronymic))
                .ForMember(empDto => empDto.Gender,
                opt => opt.MapFrom(emp => emp.Gender))
                .ForMember(empDto => empDto.BirthDate,
                opt => opt.MapFrom(emp => emp.BirthDate))
                .ForMember(empDto => empDto.PersonType,
                opt => opt.MapFrom(emp => emp.PersonType))
                .ForMember(empDto => empDto.EmailAddress,
                opt => opt.MapFrom(emp => emp.EmailAddress))
                .ForMember(empDto => empDto.PhoneNumber,
                opt => opt.MapFrom(emp => emp.PhoneNumber))
                .ForMember(empDto => empDto.SNILS,
                opt => opt.MapFrom(emp => emp.SNILS))
                .ForMember(empDto => empDto.InsuranceNumber,
                opt => opt.MapFrom(emp => emp.InsuranceNumber))
                .ForMember(empDto => empDto.PassportSeries,
                opt => opt.MapFrom(emp => emp.PassportSeries))
                .ForMember(empDto => empDto.PassportNumber,
                opt => opt.MapFrom(emp => emp.PassportNumber))
                .ForMember(empDto => empDto.PassportDate,
                opt => opt.MapFrom(emp => emp.PassportDate))
                .ForMember(empDto => empDto.PassportPlace,
                opt => opt.MapFrom(emp => emp.PassportPlace))
                .ForMember(empDto => empDto.Comment,
                opt => opt.MapFrom(emp => emp.Comment));
 



        }
    }
}
