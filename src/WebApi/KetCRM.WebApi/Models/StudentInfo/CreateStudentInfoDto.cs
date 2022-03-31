using AutoMapper;
using KetCRM.Application.Common.Mapping;
using KetCRM.Application.StudentInfoBl.Commands.CreateStudentInfo;

namespace KetCRM.WebApi.Models.StudentInfo
{
    public class CreateStudentInfoDto:IMapFrom<CreateStudentInfoCommand>
    {
        public int PersonId { get; set; }
        public bool Dormitory { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateStudentInfoDto, CreateStudentInfoCommand>()
                .ForMember(empcommand => empcommand.PersonId,
                opt => opt.MapFrom(empdto => empdto.PersonId))
                .ForMember(empcommand => empcommand.Dormitory,
                opt => opt.MapFrom(empdto => empdto.Dormitory));
        }
    }
}
