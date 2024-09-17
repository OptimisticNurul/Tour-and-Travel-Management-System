using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tour_Travel.Models
{
    public class TourAvailability
    {
        public int TourAvailabilityId { get; set; }
        [Required]
        [ForeignKey("Tour")]
        public int TourId { get; set; }
        [Required,
            DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required,
            Display(Name = "Available Slots")]
        public int AvailableSlots { get; set; }
        public Tour? Tour { get; set; } 
    }
}
