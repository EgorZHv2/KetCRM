using AutoMapper;
using AutoMapper.QueryableExtensions;
using KetCRM.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.GroupBl.Queries.GetGroupList
{
    public class GetGroupListQueryHandler: IRequestHandler<GetGroupListQuery,GroupListVM>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbcontext;

        public GetGroupListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public async Task<GroupListVM> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
        {
            var empQuery = await _dbcontext.Persons
                .ProjectTo<GroupItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new GroupListVM { Lists = empQuery };

        }
    }
}
