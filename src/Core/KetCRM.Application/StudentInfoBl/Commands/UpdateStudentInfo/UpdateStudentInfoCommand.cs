using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace KetCRM.Application.StudentInfoBl.Commands.UpdateStudentInfo
{
    public class UpdateStudentInfoCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public bool Dormitory { get; set; }
    }
}
