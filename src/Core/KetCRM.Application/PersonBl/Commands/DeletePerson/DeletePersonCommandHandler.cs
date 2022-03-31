using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetCRM.Application.Common.Interfaces;
using KetCRM.Application.Common.Exceptions;
using KetCRM.Domain.Entities;
using MediatR;

namespace KetCRM.Application.PersonBl.Commands.DeletePerson
{
    public class DeletePersonCommandHandler:IRequestHandler<DeletePersonCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeletePersonCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeletePersonCommand request,CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Persons.FindAsync(new object[] { request.Id }, cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }
            _dbContext.Persons.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
