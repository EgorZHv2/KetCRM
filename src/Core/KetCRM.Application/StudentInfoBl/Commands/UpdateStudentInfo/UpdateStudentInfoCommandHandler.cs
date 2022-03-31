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
            studentinfo.PersonId = request.PersonId;
            studentinfo.Dormitory = request.Dormitory;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
