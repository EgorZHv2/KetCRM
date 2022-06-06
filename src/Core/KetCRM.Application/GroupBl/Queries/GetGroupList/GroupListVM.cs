using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.GroupBl.Queries.GetGroupList
{
    public class GroupListVM
    {
        public IList<GroupItemDto> Lists { get; set; } = new List<GroupItemDto>();
    }
}
