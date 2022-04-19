using KetCRM.Application.Common.Interfaces;
using KetCRM.Application.Models;
using KetCRM.Domain.Entities;

namespace KetCRM.Application.Services
{
    public class PersonService : IPersonService
    {
        private IApplicationDbContext _context;

        public PersonService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> CreatePerson(CreatePersonModel model)
        {
            Result result = new Result();

            Person person = new Person()
            {
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                Gender = model.Gender,
                BirthDate = model.BirthDate,
                PassportDate = model.PassportDate,
                PassportNumber = model.PassportNumber,
                PersonType = model.PersonType,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                Snils = model.Snils,
                InsuranceNumber = model.InsuranceNumber,
                PassportSeries = model.PassportSeries,
                PassportPlace = model.PassportPlace,
                Comment = model.Comment,
                Photo = model.Photo,
            };
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}