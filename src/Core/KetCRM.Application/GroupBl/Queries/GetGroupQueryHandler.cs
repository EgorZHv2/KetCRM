using AutoMapper;
using KetCRM.Application.Common.Exceptions;
using KetCRM.Application.Common.Interfaces;
using KetCRM.Application.GroupBl.Queries.GetGroupList;
using KetCRM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.GroupBl.Queries
{
    public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, GroupItemDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbcontext;

        public GetGroupQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public async Task<GroupItemDto> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Groups.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }


            return new GroupItemDto
            {
                Id = entity.Id,
                SpecializationId = entity.SpecializationId,
                AfterEleven = entity.AfterEleven,
                FormOfEducationId = entity.FormOfEducationId,
                PersonTeacherId = entity.PersonTeacherId,
                PersonElderId = entity.PersonElderId,
                DepartmentId = entity.DepartmentId,
                CourseNumber = entity.CourseNumber,
                GroupNumber = entity.GroupNumber

            };
        }
    }
}
