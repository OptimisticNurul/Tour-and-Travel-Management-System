using System.ComponentModel.DataAnnotations;

namespace Tour_Travel.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required, StringLength(100), Display(Name = "User Name")]
        public string UserName { get; set; } = default!;
        [Required, StringLength(50)]
        public string Password { get; set; } = default!;
        [Required, StringLength(100)]
        public string Role { get; set; } = default!;
    }
}
