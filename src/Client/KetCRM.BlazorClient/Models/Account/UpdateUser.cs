using System.ComponentModel.DataAnnotations;

namespace KetCRM.BlazorClient.Models.Account
{
    public class UpdateUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Role { get; set; }
        public byte[]? Image { get; set; }
    }
}
