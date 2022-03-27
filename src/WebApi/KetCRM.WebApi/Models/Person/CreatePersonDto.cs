using AutoMapper;
using KetCRM.Application.PersonBl.Commands.CreatePerson;
using KetCRM.Application.Common.Mapping;

namespace KetCRM.WebApi.Models.Person
{
    public class CreatePersonDto:IMapFrom<CreatePersonCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonDto, CreatePersonCommand>()
                .ForMember(EmpCommand => EmpCommand.Name,
                    opt => opt.MapFrom(empDto => empDto.Name))
                .ForMember(EmpCommand => EmpCommand.Surname,
                    opt => opt.MapFrom(empDto => empDto.Surname))
                .ForMember(EmpCommand => EmpCommand.Patronymic,
                    opt => opt.MapFrom(empDto => empDto.Patronymic));
                
        }
    }
}
