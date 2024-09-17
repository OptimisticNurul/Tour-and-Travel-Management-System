using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required,
            StringLength(50),
            Display(Name ="User Name")]
        public string UserName { get; set; } = default!;
        [Required, 
            StringLength(50)]
        public string Password { get; set; } = default!;
        [Required, 
            StringLength(100)]
        public string Email { get; set; } = default!;
        [Required, 
            StringLength(50)]
        public string Role { get; set; } = default!;
        [Required, 
            StringLength(50), 
            Display(Name = "Profile Image")]
        public string ProfileImage { get; set; } = default!;
        public ICollection<TourBooking> Bookings { get; set; }=new List<TourBooking>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
    }
}
