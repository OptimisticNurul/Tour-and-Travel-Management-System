using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class TourHotel
    {
        public int TourHotelId { get; set; }
        [Required,
            StringLength(100),
            Display(Name = "Hotel Name")]
        public string HotelName { get; set; } = default!;
        [Required,
            StringLength(100)]
        public string Location { get; set; } = default!;
        [Required,
            Column(TypeName = "decimal(3, 2)")]
        public decimal Rating { get; set; }
        [Required,
            StringLength(500)]
        public string Description { get; set; } = default!;
        [Required,
            Column(TypeName = "decimal(10, 2)"),
            Display(Name = "Price PerNight")]
        public decimal PricePerNight { get; set; }
        public ICollection<TourPackage> Packages { get; set; } = new List<TourPackage>();
    }
}
