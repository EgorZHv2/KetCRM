﻿using KetCRM.BlazorClient.Models.Account;

namespace KetCRM.BlazorClient.Services.Account
{
    public interface IAccountService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task Logout();
    }
}