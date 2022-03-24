using KetCRM.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KetCRM.Application.Common.Exceptions;
using KetCRM.Domain.Entities;

namespace KetCRM.Application.PersonBl.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdatePersonCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(emp => 
            emp.Id == request.Id, cancellationToken);
            if(person == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }
            person.Name = request.Name;
            person.Surname = request.Surname;
            person.Patronymic = request.Patronymic;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}