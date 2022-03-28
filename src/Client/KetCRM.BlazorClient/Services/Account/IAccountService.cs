using KetCRM.BlazorClient.Models.Account;
using KetCRM.BlazorClient.Models.Manager;

namespace KetCRM.BlazorClient.Services.Account
{
    public interface IAccountService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task Logout();
        Task<UpdateResult> UpdateUser(UpdateUser updateUser, string name);
    }
}
