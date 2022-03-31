using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediatR;


namespace KetCRM.Application.StudentInfoBl.Commands.CreateStudentInfo;

public class CreateStudentInfoCommand : IRequest<int>
{
    [Required]
    public int PersonId { get; set; }
    [Required]
    public bool Dormitory { get; set; }

}
