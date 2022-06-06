using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.GroupBl.Queries.GetGroupList
{
    public class GetGroupQuery:IRequest<GroupItemDto>
    {
        [Required]
        public int Id { get; set; }
    }
}
