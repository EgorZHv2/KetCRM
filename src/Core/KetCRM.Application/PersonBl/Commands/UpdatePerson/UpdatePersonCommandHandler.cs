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
            person.Gender = request.Gender;
            person.BirthDate = request.BirthDate;
            person.PersonType = request.PersonType;
            person.EmailAddress = request.EmailAddress;
            person.PhoneNumber = request.PhoneNumber;
            person.SNILS = request.SNILS;
            person.InsuranceNumber = request.InsuranceNumber;
            person.PassportSeries = request.PassportSeries;
            person.PassportNumber = request.PassportNumber;
            person.PassportDate = request.PassportDate;
            person.PassportPlace = request.PassportPlace;
            person.Comment = request.Comment;

             
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}