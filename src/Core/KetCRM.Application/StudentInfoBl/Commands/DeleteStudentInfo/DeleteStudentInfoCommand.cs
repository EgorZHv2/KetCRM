using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KetCRM.Application.StudentInfoBl.Commands.DeleteStudentInfo
{
    public class DeleteStudentInfoCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
