using KetCRM.BlazorClient.Models.Manager;

namespace KetCRM.BlazorClient.Services.Manager
{
    public class ManagerService : IManagerService
    {
        private readonly HttpClient _httpClient;
        public ManagerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserListModel> GetAllUser()
        {
            UserListModel userList = await _httpClient.GetFromJsonAsync<UserListModel>("api/manager/getalluser");

            return userList;
        }
    }
}
