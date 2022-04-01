using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediatR;
using KetCRM.Application.Common.Interfaces;
using KetCRM.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using KetCRM.Domain.Entities;

namespace KetCRM.Application.StudentInfoBl.Commands.UpdateStudentInfo
{
    public class UpdateStudentInfoCommandHandler : IRequestHandler<UpdateStudentInfoCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateStudentInfoCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateStudentInfoCommand request, CancellationToken cancellationToken)
        {
            var studentinfo = await _dbContext.StudentInfos.FirstOrDefaultAsync(emp
                => emp.Id == request.Id, cancellationToken);
            if (studentinfo == null)
            {
                throw new NotFoundException(nameof(StudentInfo), request.Id);
            }
            studentinfo.StudiedLanguageId = request.StudiedLanguageId;
            studentinfo.Dormitory = request.Dormitory;
            studentinfo.HasTwo = request.HasTwo;
            studentinfo.SchoolCertificateNumber = request.SchoolCertificateNumber;
            studentinfo.YearOfReleaseFromSchool = request.YearOfReleaseFromSchool;
            studentinfo.HasMedal = request.HasMedal;
            studentinfo.GraduatedSchool = request.GraduatedSchool;
            studentinfo.SchoolTypeId = request.SchoolTypeId;
            studentinfo.OnABudget = request.OnABudget;
            studentinfo.TargetedEducation = request.TargetedEducation;
            studentinfo.PersonId = request.PersonId;
            studentinfo.SchoolEducationTypeId = request.SchoolEducationTypeId;
            studentinfo.OlimpiadeWinner = request.OlimpiadeWinner;
            studentinfo.WorkExperience = request.WorkExperience;
            studentinfo.StudentStatusId = request.StudentStatusId;
            studentinfo.StudentCerteficateNumber = request.StudentCerteficateNumber;
            studentinfo.StudentCardNumber = request.StudentCardNumber;
            studentinfo.StudentRecordBookNumber = request.StudentRecordBookNumber;
            studentinfo.PassCardNumber = request.PassCardNumber;
            studentinfo.NeedIssuePassCard = request.NeedIssuePassCard;



            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
