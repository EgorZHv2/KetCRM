using KetCRM.Application.DTOs.Account;
using KetCRM.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.Interfaces.Account
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<UserListVM> AuthenticateUserList();
        Task<string> DeleteUser(string userId);
        Task<UpdateUserDto> UpdateUserById(UpdateUserDto request, string userId);
        Task<UpdateUserDto> GetUserById(string userId);
    }
}
