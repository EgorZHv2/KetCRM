using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.DTOs.Account
{
    public class UserListVM
    {
        public IList<UserListDto> Lists { get; set; } = new List<UserListDto>();
    }
}
