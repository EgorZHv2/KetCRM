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
namespace KetCRM.Application.PersonBl.Queries.GetPersonList
{
    public class GetPersonQueryHandler:IRequestHandler<GetPersonQuery,PersonVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbcontext;

        public GetPersonQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public async Task<PersonVm> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Persons.FindAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }
            
            
            return new PersonVm {person = entity};
        }
    }
}
