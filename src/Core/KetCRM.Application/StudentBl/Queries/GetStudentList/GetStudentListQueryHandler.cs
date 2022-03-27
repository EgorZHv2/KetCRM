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

namespace KetCRM.Application.StudentBl.Queries.GetStudentList
{
   public class GetStudentListQueryHandler:IRequestHandler<GetStudentListQuery,StudentListVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbcontext;

        public GetStudentListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public async Task<StudentListVm> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var empQuery = await _dbcontext.StudentInfos
                .ProjectTo<StudentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new StudentListVm { Lists = empQuery };

        }
    }
}
