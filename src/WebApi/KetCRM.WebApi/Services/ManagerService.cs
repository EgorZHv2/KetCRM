using KetCRM.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace KetCRM.Identity.Services
{
    public class ManagerService : IManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserListModel> GetAllUser()
        {
            UserListModel users = new UserListModel();

            users.Lists = (from userItem in _userManager.Users
                           select new UserListDto
                           {
                               Id = userItem.Id,
                               Name = userItem.Name,
                               Surname = userItem.Surname,
                               Patronymic = userItem.Patronymic,
                               Login = userItem.UserName,
                               LastLogin = (userItem.LastLogin).ToString(),
                               Email = userItem.Email,
                           }).ToList();

            foreach (var item in users.Lists)
            {
                var entity = await _userManager.FindByIdAsync(item.Id);
                item.Roles = string.Join("; ", await _userManager.GetRolesAsync(entity));
            }

            return users;
        }
    }
}
