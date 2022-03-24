using KetCRM.BlazorClient.Models.Manager;

namespace KetCRM.BlazorClient.Services.Manager
{
    public interface IManagerService
    {
        Task<UserListModel> GetAllUser();
        Task<AvatarModel> GetAvatar(string name);
        Task<UserModel> GetUserByName(string name);
    }
}
