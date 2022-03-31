using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using KetCRM.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using KetCRM.Application.Common.Exceptions;
using KetCRM.Domain.Entities;
using KetCRM.Application.StudentInfoBl.Queries.GetStudentInfoList;

namespace KetCRM.Application.StudentInfoBl.Queries
{
    internal class GetStudentInfoQueryHandler:IRequestHandler<GetStudentInfoQuery,StudentInfoItemDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbcontext;

        public GetStudentInfoQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public async Task<StudentInfoItemDto> Handle(GetStudentInfoQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.StudentInfos.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }


            return new StudentInfoItemDto
            {
                Id = entity.Id,
                StudiedLanguageId = entity.StudiedLanguageId,
                Dormitory = entity.Dormitory,
                GroupId = entity.GroupId,
                HasTwo = entity.HasTwo,
                SchoolCertificateNumber = entity.SchoolCertificateNumber,
                YearOfReleaseFromSchool = entity.YearOfReleaseFromSchool,
                HasMedal = entity.HasMedal,
                GraduatedSchool = entity.GraduatedSchool,
                SchoolTypeId = entity.SchoolTypeId,
                OnABudget = entity.OnABudget,
                TargetedEducation = entity.TargetedEducation,
                PersonId = entity.PersonId,
                SchoolEducationTypeId = entity.SchoolEducationTypeId,
                OlimpiadeWinner = entity.OlimpiadeWinner,
                WorkExperience = entity.WorkExperience,
                StudentStatusId = entity.StudentStatusId,
                StudentCerteficateNumber = entity.StudentCerteficateNumber,
                StudentCardNumber = entity.StudentCardNumber,
                StudentRecordBookNumber = entity.StudentRecordBookNumber,
                PassCardNumber = entity.PassCardNumber,
                NeedIssuePassCard = entity.NeedIssuePassCard
            };
        }
    }
}
