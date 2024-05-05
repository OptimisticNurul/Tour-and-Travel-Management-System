using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tour_Travel.Models
{
    public class TourCancellation
    {
        public int TourCancellationId { get; set; }
        [Required]
        [ForeignKey("TourBooking")]
        public int TourBookingId { get; set; }
        [Required,
            DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            Display(Name = "Cancellation Date")]
        public DateTime CancellationDate { get; set; }
        [Required,
            StringLength(500)]
        public string Reason { get; set; } = default!;
        public TourBooking? TourBooking { get; set; }
    }
}
