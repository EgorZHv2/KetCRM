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
using KetCRM.Domain.Entities;

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
            StudentListVm output = new StudentListVm();
            foreach(var s in _dbcontext.StudentInfos)
            {
                var p = await _dbcontext.Persons.FindAsync(new object[] { s.PersonId }, cancellationToken);
                output.Lists.Add(new StudentItemDto
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Patronymic = p.Patronymic,
                    Gender = p.Gender,
                    BirthDate = p.BirthDate,
                    PassportSeries = p.PassportSeries,
                    PassportNumber = p.PassportNumber,
                    GroupId = s.GroupId,
                    OnABudget = s.OnABudget,
                    TargetedEducation = s.TargetedEducation,
                    StudiedLanguageId = s.StudiedLanguageId,
                    HasTwo = s.HasTwo,
                    HasMedal = s.HasMedal


                }) ;
            }
            return output;


        }
    }
}
