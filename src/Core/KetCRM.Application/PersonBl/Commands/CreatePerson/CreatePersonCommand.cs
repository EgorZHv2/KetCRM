using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace KetCRM.Application.PersonBl.Commands.CreatePerson;

internal class CreatePersonCommand:IRequest<int>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Patronymic { get; set; }
}
