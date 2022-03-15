using KetCRM.BlazorClient.Models;

namespace KetCRM.BlazorClient.Services.Interfaces.Account
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> Login(LoginVM loginModel);
        Task Logout();
    }
}
