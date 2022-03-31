using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.StudentInfoBl.Queries.GetStudentInfoList
{
    public class StudentInfoListVm
    {
        public IList<StudentInfoItemDto> Lists { get; set; } = new List<StudentInfoItemDto>();
    }
}
