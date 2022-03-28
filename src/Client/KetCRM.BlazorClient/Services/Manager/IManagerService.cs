using KetCRM.BlazorClient.Models.Manager;

namespace KetCRM.BlazorClient.Services.Manager
{
    public interface IManagerService
    {
        Task<UserListModel> GetAllUser(string filter);
        Task<UserListModel> GetAllUser();
        Task<AvatarModel> GetAvatar(string name);
        Task<UserModel> GetUserByName(string name);
        Task<bool> DeleteUserByName(string name);
    }
}
