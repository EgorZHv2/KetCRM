using AutoMapper;
using KetCRM.Application.Common.Interfaces;
using KetCRM.Application.StudentBl.Queries.GetStudentList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.StudentBl.Queries.GetStudentListByGroup
{
    public class GetStudentListByGroupQueryHandler : IRequestHandler<GetStudentListByGroupQuery, StudentListVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbcontext;

        public GetStudentListByGroupQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public async Task<StudentListVm> Handle(GetStudentListByGroupQuery request, CancellationToken cancellationToken)
        {
            StudentListVm output = new StudentListVm();
            foreach (var s in _dbcontext.StudentInfos)
            {
                var entity = await _dbcontext.Persons.FindAsync(new object[] { s.PersonId }, cancellationToken);
                var studentinfo = await _dbcontext.StudentInfos.FindAsync(new object[] { s.PersonId }, cancellationToken);
                if(request.Name == _dbcontext.Groups.Find(s.GroupId).CourseNumber + "-"
                    + _dbcontext.Groups.Find(s.GroupId).GroupNumber +" "+
                      _dbcontext.Specializations.Find(_dbcontext.Groups.Find(s.GroupId).SpecializationId).Name)
                      
                {                                  
                    output.Lists.Add(new StudentItemDto
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Surname = entity.Surname,
                        Patronymic = entity.Patronymic,
                        Gender = entity.Gender,
                        BirthDate = entity.BirthDate,
                        PersonType = entity.PersonType,
                        EmailAddress = entity.EmailAddress,
                        PhoneNumber = entity.PhoneNumber,
                        SNILS = entity.SNILS,
                        InsuranceNumber = entity.InsuranceNumber,
                        PassportSeries = entity.PassportSeries,
                        PassportNumber = entity.PassportNumber,
                        PassportDate = entity.PassportDate,
                        PassportPlace = entity.PassportPlace,
                        Comment = entity.Comment,
                        StudiedLanguageId = s.StudiedLanguageId,
                        Dormitory = s.Dormitory,
                        GroupId = s.GroupId,
                        HasTwo = s.HasTwo,
                        SchoolCertificateNumber = s.SchoolCertificateNumber,
                        YearOfReleaseFromSchool = s.YearOfReleaseFromSchool,
                        HasMedal = s.HasMedal,
                        GraduatedSchool = s.GraduatedSchool,
                        SchoolTypeId = s.SchoolTypeId,
                        OnABudget = s.OnABudget,
                        TargetedEducation = s.TargetedEducation,
                        PersonId = s.PersonId,
                        SchoolEducationTypeId = s.SchoolEducationTypeId,
                        OlimpiadeWinner = s.OlimpiadeWinner,
                        WorkExperience = s.WorkExperience,
                        StudentStatusId = s.StudentStatusId,
                        StudentCerteficateNumber = s.StudentCerteficateNumber,
                        StudentCardNumber = s.StudentCardNumber,
                        StudentRecordBookNumber = s.StudentRecordBookNumber,
                        PassCardNumber = s.PassCardNumber,
                        NeedIssuePassCard = s.NeedIssuePassCard
                    });
                }              
            }
            return output;


        }
    }
}
