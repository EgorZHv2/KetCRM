using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace KetCRM.Application.PersonBl.Commands.DeletePerson
{
    public class DeletePersonCommand: IRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
