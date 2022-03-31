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
                PersonId = request.PersonId,
                Dormitory = request.Dormitory
            };
            await _dbcontext.StudentInfos.AddAsync(student, cancellationToken);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return student.Id;
        }
    }
}
