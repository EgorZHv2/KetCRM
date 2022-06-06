using KetCRM.Application.StudentBl.Queries.GetStudentList;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.StudentBl.Queries.GetStudentListByGroup
{
    public class GetStudentListByGroupQuery : IRequest<StudentListVm>
    {
        [Required]
       public string Name { get; set; }
    }
}
