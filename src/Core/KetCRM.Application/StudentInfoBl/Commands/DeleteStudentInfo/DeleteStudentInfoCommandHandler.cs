using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using KetCRM.Application.Common.Interfaces;
using KetCRM.Application.Common.Exceptions;
using KetCRM.Domain.Entities;

namespace KetCRM.Application.StudentInfoBl.Commands.DeleteStudentInfo
{
    public class DeleteStudentInfoCommandHandler : IRequestHandler<DeleteStudentInfoCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteStudentInfoCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteStudentInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.StudentInfos.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(StudentInfo), request.Id);
            }
            _dbContext.StudentInfos.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
