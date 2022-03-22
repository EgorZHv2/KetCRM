using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.PersonBl.Queries.GetPersonList
{
    public class PersonListVm
    {
        public IList<PersonItemDto> Lists { get; set; } = new List<PersonItemDto>();
    }
}
