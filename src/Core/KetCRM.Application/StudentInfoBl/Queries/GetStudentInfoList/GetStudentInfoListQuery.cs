using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace KetCRM.Application.StudentInfoBl.Queries.GetStudentInfoList
{
    public class GetStudentInfoListQuery : IRequest<StudentInfoListVm>
    {
    }
}
