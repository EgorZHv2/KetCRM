using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.ComponentModel.DataAnnotations;
using KetCRM.Application.PersonBl.Queries.GetPersonList;

namespace KetCRM.Application.PersonBl.Queries
{
    public class GetPersonQuery:IRequest<PersonItemDto>
    {
        [Required]
        public int Id { get; set; }
    }
}
