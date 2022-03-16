using KetCRM.Application.DTOs.Account;
using KetCRM.Application.Enums;
using KetCRM.Application.Exceptions;
using KetCRM.Application.Interfaces;
using KetCRM.Application.Interfaces.Account;
using KetCRM.Application.Wrappers;
using KetCRM.Domain.Settings;
using KetCRM.Infrastructure.Identity.Helpers;
using KetCRM.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace KetCRM.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _jwtSettings;
        private readonly IImageReader _imageReader;
        private readonly IDateTimeService _dateTimeService;
        public AccountService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JWTSettings> jwtSettings,
            IImageReader imageReader,
            IDateTimeService dateTimeService,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _imageReader = imageReader;
            _dateTimeService = dateTimeService;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ApiException($"No Accounts Registered with {request.Email}.");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"Invalid Credentials for '{request.Email}'.");
            }
            

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.Name = user.Name;
            response.Surname = user.Surname;
            response.Login = user.UserName;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
            var refreshToken = GenerateRefreshToken(ipAddress);
            response.RefreshToken = refreshToken.Token;

            user.LastLogin = DateTime.Now;
            await _userManager.UpdateAsync(user);

            return response;
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.Login);
            if (userWithSameUserName != null)
            {
                throw new ApiException($"Username '{request.Login}' is already taken.");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                UserName = request.Login,
            };

            //if (request.UploadedFile != null)
            //{
            //    user.Image = _imageReader.ReadImage(request.UploadedFile);
            //}

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, ((Roles)request.Roles).ToString());
                    return new Response<string>(user.Id, message: $"User Registered.");
                }
                else
                {
                    throw new ApiException($"{result.Errors}");
                }
            }
            else
            {
                throw new ApiException($"Email {request.Email } is already registered.");
            }
        }

        public async Task<UserListVM> AuthenticateUserList()
        {
            UserListVM users = new UserListVM();

            users.Lists = (from userItem in _userManager.Users
                           select new UserListDto
                           {
                               Id = userItem.Id,
                               Name = userItem.Name,
                               Surname = userItem.Surname,
                               Patronymic = userItem.Patronymic,
                               Login = userItem.UserName,
                               LastLogin = (userItem.LastLogin).ToString("G"),
                               Email = userItem.Email,
                           }).ToList();

            foreach (var item in users.Lists)
            {
                var entity = await _userManager.FindByIdAsync(item.Id);
                item.Roles = string.Join("; ", await _userManager.GetRolesAsync(entity));
            }

            return users;
        }

        public async Task<string> DeleteUser(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            if(user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return userId;
        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            string ipAddress = IpHelper.GetIpAddress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                new Claim("ip", ipAddress),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Surname)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }
    }
}
