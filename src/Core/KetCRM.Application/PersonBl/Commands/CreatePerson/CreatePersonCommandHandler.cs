using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using KetCRM.Application.Common.Interfaces;
using KetCRM.Domain.Entities;

namespace KetCRM.Application.PersonBl.Commands.CreatePerson;

public class CreatePersonCommandHandler:IRequestHandler<CreatePersonCommand,int>
{
    private readonly IApplicationDbContext _dbContext;
    public CreatePersonCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> Handle(CreatePersonCommand request,CancellationToken cancellationToken)
    {
        var person = new Person
        {
            Name = request.Name,
            Surname = request.Surname,
            Patronymic = request.Patronymic
        };
        await _dbContext.Persons.AddAsync(person, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return person.Id;
    }
}
