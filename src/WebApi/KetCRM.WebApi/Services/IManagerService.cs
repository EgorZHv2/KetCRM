using KetCRM.Identity.Models;

namespace KetCRM.Identity.Services
{
    public interface IManagerService
    {
        Task<UserListModel> GetAllUser();
    }
}
