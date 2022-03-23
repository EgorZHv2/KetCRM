namespace KetCRM.BlazorClient.Models.Manager
{
    public class UserListModel
    {
        public IList<UserListDto> Lists { get; set; } = new List<UserListDto>();
    }
}
