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

namespace KetCRM.Application.StudentInfoBl.Queries.GetStudentInfoList
{
    public class GetStudentInfoListQueryHandler : IRequestHandler<GetStudentInfoListQuery, StudentInfoListVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbcontext;

        public GetStudentInfoListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public async Task<StudentInfoListVm> Handle(GetStudentInfoListQuery request, CancellationToken cancellationToken)
        {
            var empQuery = await _dbcontext.StudentInfos.ProjectTo<StudentInfoItemDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new StudentInfoListVm { Lists = empQuery };

        }
    }
}
