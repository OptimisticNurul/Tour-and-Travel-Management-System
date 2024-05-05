using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tour_Travel.Models
{
    public class Refund
    {
        public int RefundId { get; set; }
        [Required]
        [ForeignKey("TourBooking")]
        public int TourBookingId { get; set; }
        [Required,
            DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            Display(Name ="Refund Date")]
        public DateTime RefundDate { get; set; }
        [Required,
            Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        public TourBooking? TourBooking { get; set; }
    }
}
