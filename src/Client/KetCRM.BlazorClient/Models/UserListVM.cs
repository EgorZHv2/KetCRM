using KetCRM.Application.DTOs.Account;

namespace KetCRM.BlazorClient.Models
{
    public class UserListVM
    {
        public IList<UserListDto> Lists { get; set; } = new List<UserListDto>();
    }
}
