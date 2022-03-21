using KetCRM.BlazorClient.Models;

namespace KetCRM.BlazorClient.Services.Account
{
    public interface IAccountService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
