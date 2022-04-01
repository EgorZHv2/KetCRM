using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using KetCRM.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using KetCRM.Application.Common.Exceptions;
using KetCRM.Domain.Entities;
using KetCRM.Application.PersonBl.Queries.GetPersonList;
namespace KetCRM.Application.PersonBl.Queries
{
    public class GetPersonQueryHandler:IRequestHandler<GetPersonQuery,PersonItemDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbcontext;

        public GetPersonQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public async Task<PersonItemDto> Handle(GetPersonQuery request,CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Persons.FindAsync(new object[] { request.Id },cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }


            return new PersonItemDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Patronymic = entity.Patronymic,
                Gender = entity.Gender,
                BirthDate = entity.BirthDate,
                PersonType = entity.PersonType,
                EmailAddress = entity.EmailAddress,
                PhoneNumber = entity.PhoneNumber,
                SNILS = entity.SNILS,
                InsuranceNumber = entity.InsuranceNumber,
                PassportSeries = entity.PassportSeries,
                PassportNumber = entity.PassportNumber,
                PassportDate = entity.PassportDate,
                PassportPlace = entity.PassportPlace,
                Comment = entity.Comment,

            };
        }
    }
}
