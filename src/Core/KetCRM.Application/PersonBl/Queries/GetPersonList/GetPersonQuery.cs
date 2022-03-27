using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KetCRM.Application.PersonBl.Queries.GetPersonList
{
    public class GetPersonQuery:IRequest<PersonItemDto>
    {
        [Required]
        public int Id { get; set; }
    }
}
