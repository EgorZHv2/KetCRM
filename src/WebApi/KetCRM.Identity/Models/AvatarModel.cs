using System.ComponentModel.DataAnnotations;

namespace KetCRM.Identity.Models
{
    public class AvatarModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] Image { get; set; }
    }
}
