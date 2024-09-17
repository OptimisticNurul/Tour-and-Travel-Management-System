using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tour_Travel.Models
{
    public class TransactionHistory
    {
        public int TransactionHistoryId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("TourBooking")]
        public int TourBookingId { get; set; }
        [Required,
            DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Required,
            Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        public User? User { get; set; } 
        public TourBooking? TourBooking { get; set; } 
    }
}
