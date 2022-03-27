using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.StudentBl.Queries.GetStudentList
{
    public class StudentListVm
    {
        public IList<StudentItemDto> Lists { get; set; } = new List<StudentItemDto>();
    }
}
