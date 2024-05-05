using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class TourImage
    {
        public int TourImageId { get; set; }
        [ForeignKey("Tour")]
        public int TourId { get; set; }
        public string Picture { get; set; } = default!;
        public Tour? Tour { get; set; }
    }
}
