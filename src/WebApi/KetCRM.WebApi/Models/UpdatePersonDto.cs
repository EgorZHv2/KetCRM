using AutoMapper;
using KetCRM.Application.PersonBl.Commands.UpdatePerson;
using KetCRM.Application.Common.Mapping;


namespace KetCRM.WebApi.Models
{
    public class UpdatePersonDto:IMapFrom<UpdatePersonCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonDto, UpdatePersonCommand>()
                .ForMember(EmpCommand => EmpCommand.Id,
                    opt => opt.MapFrom(empDto => empDto.Id))
                .ForMember(EmpCommand => EmpCommand.Name,
                    opt => opt.MapFrom(empDto => empDto.Name))
                .ForMember(EmpCommand => EmpCommand.Surname,
                    opt => opt.MapFrom(empDto => empDto.Surname))
                .ForMember(EmpCommand => EmpCommand.Patronymic,
                    opt => opt.MapFrom(empDto => empDto.Patronymic));
        }
    }
}
