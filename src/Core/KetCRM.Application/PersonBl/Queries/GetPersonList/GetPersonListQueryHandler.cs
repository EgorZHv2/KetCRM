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

namespace KetCRM.Application.PersonBl.Queries.GetPersonList
{
    public class GetPersonListQueryHandler: IRequestHandler<GetPersonListQuery,PersonListVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbcontext;
        
        public GetPersonListQueryHandler(IApplicationDbContext dbContext,IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public async Task<PersonListVm> Handle(GetPersonListQuery request,CancellationToken cancellationToken)
        {
            var empQuery = await _dbcontext.Persons
                .ProjectTo<PersonItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new PersonListVm { Lists = empQuery };
                
        }

    }
}
