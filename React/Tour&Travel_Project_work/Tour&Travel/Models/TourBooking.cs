using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class TourBooking
    {
        public int TourBookingId { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Tour")]
        public int TourId { get; set; }
        [DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public int NumberOfPersons { get; set; }
        [Required,
            Column(TypeName = "decimal(10, 2)"),
            Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [ForeignKey("Promotion")]
        public int? PromotionId { get; set; }
        public Tour? Tour { get; set; }
        public User? User { get; set; }
        public Promotion? Promotion { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Refund> Refunds { get; set; } = new List<Refund>();
        public ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
        public ICollection<TourCancellation> TourCancellations { get; set; } = new List<TourCancellation>();
    }
}
