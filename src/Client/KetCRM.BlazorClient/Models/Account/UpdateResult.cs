namespace KetCRM.BlazorClient.Models.Account
{
    public class UpdateResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
