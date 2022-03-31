using AutoMapper;
using KetCRM.Application.Common.Mapping;
using KetCRM.Application.StudentInfoBl.Commands.UpdateStudentInfo;

namespace KetCRM.WebApi.Models.StudentInfo
{
    public class UpdateStudentInfoDto:IMapFrom<UpdateStudentInfoCommand>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public bool Dormitory { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateStudentInfoDto, UpdateStudentInfoCommand>()
                .ForMember(empcommand => empcommand.Id,
                opt => opt.MapFrom(empdto => empdto.Id))
                .ForMember(empcommand => empcommand.PersonId,
                opt => opt.MapFrom(empdto => empdto.PersonId))
                .ForMember(empcommand => empcommand.Dormitory,
                opt => opt.MapFrom(empdto => empdto.Dormitory));
        }
    }
}
