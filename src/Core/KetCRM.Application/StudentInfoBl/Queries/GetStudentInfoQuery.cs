using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.ComponentModel.DataAnnotations;
using KetCRM.Application.StudentInfoBl.Queries.GetStudentInfoList;

namespace KetCRM.Application.StudentInfoBl.Queries
{
    public class GetStudentInfoQuery: IRequest<StudentInfoItemDto>
    {
        public int Id { get; set; }
    }
}
