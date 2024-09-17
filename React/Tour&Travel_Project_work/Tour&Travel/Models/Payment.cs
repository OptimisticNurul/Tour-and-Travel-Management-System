using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tour_Travel.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        [Required]
        [ForeignKey("TourBooking")]
        public int TourBookingId { get; set; }
        [Required,
            DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }
        [Required,
            Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        [Required,
            StringLength(100),
            Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } = default!;
        public TourBooking? TourBooking { get; set; }
    }
}
