using AutoMapper;
using KetCRM.Application.Common.Mapping;
using KetCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.GroupBl.Queries.GetGroupList
{
    public class GroupItemDto : IMapFrom<Group>
    {
        public int Id { get; set; }
        public int? SpecializationId { get; set; }
        public bool? AfterEleven { get; set; }
        public int? FormOfEducationId { get; set; }
        public int? PersonTeacherId { get; set; }
        public int? PersonElderId { get; set; }
        public int? DepartmentId { get; set; }
        public string? CourseNumber { get; set; }
        public string? GroupNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupItemDto>()
            .ForMember(empDto => empDto.Id,
            opt => opt.MapFrom(emp => emp.Id))
            .ForMember(empDto => empDto.SpecializationId,
            opt => opt.MapFrom(emp => emp.SpecializationId))
            .ForMember(empDto => empDto.AfterEleven,
            opt => opt.MapFrom(emp => emp.AfterEleven))
            .ForMember(empDto => empDto.FormOfEducationId,
            opt => opt.MapFrom(emp => emp.FormOfEducationId))
            .ForMember(empDto => empDto.PersonTeacherId,
            opt => opt.MapFrom(emp => emp.PersonTeacherId))
            .ForMember(empDto => empDto.PersonElderId,
            opt => opt.MapFrom(emp => emp.PersonElderId))
            .ForMember(empDto => empDto.DepartmentId,
            opt => opt.MapFrom(emp => emp.DepartmentId))
            .ForMember(empDto => empDto.CourseNumber,
            opt => opt.MapFrom(emp => emp.CourseNumber))
            .ForMember(empDto => empDto.GroupNumber,
            opt => opt.MapFrom(emp => emp.GroupNumber));



        }
    }
    
}
