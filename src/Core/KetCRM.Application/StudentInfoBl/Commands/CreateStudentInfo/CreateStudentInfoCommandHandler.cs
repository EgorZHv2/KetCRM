using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using KetCRM.Application.Common.Interfaces;
using KetCRM.Domain.Entities;

namespace KetCRM.Application.StudentInfoBl.Commands.CreateStudentInfo
{
    public class CreateStudentInfoCommandHandler : IRequestHandler<CreateStudentInfoCommand, int>
    {
        private readonly IApplicationDbContext _dbcontext;
        public CreateStudentInfoCommandHandler(IApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<int> Handle(CreateStudentInfoCommand request, CancellationToken cancellationToken)
        {
            var student = new StudentInfo
            {
                StudiedLanguageId = request.StudiedLanguageId,
                Dormitory = request.Dormitory,
                GroupId = request.GroupId,
                HasTwo = request.HasTwo,
                SchoolCertificateNumber = request.SchoolCertificateNumber,
                YearOfReleaseFromSchool = request.YearOfReleaseFromSchool,
                HasMedal = request.HasMedal,
                GraduatedSchool = request.GraduatedSchool,
                SchoolTypeId = request.SchoolTypeId,
                OnABudget = request.OnABudget,
                TargetedEducation = request.TargetedEducation,
                PersonId = request.PersonId,
                SchoolEducationTypeId = request.SchoolEducationTypeId,
                OlimpiadeWinner = request.OlimpiadeWinner,
                WorkExperience = request.WorkExperience,
                StudentStatusId = request.StudentStatusId,
                StudentCerteficateNumber = request.StudentCerteficateNumber,
                StudentCardNumber = request.StudentCardNumber,
                StudentRecordBookNumber = request.StudentRecordBookNumber,
                PassCardNumber = request.PassCardNumber,
                NeedIssuePassCard = request.NeedIssuePassCard
            };
            await _dbcontext.StudentInfos.AddAsync(student, cancellationToken);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return student.Id;
        }
    }
}
