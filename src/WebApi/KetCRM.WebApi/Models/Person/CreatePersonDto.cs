using AutoMapper;
using KetCRM.Application.PersonBl.Commands.CreatePerson;
using KetCRM.Application.Common.Mapping;

namespace KetCRM.WebApi.Models.Person
{
    public class CreatePersonDto:IMapFrom<CreatePersonCommand>
    {
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
            profile.CreateMap<CreatePersonDto, CreatePersonCommand>()
                .ForMember(EmpCommand => EmpCommand.Name,
                    opt => opt.MapFrom(empDto => empDto.Name))
                .ForMember(EmpCommand => EmpCommand.Surname,
                    opt => opt.MapFrom(empDto => empDto.Surname))
                .ForMember(EmpCommand => EmpCommand.Patronymic,
                    opt => opt.MapFrom(empDto => empDto.Patronymic))
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
