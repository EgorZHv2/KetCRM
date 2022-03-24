using KetCRM.Identity.Models;

namespace KetCRM.Identity.Services
{
    public interface IManagerService
    {
        Task<UserListModel> GetAllUser();
        Task<AvatarModel> GetAvatar(string name);
        Task<UserModel> GetUserByName(string name);
    }
}
