using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class Tour
    {
        public int TourId { get; set; }
        [Required,
            StringLength(100),
            Display(Name = "Tour Name")]
        public string TourName { get; set; } = default!;
        [Required,
            StringLength(200)]
        public string Destination { get; set; } = default!;
        [Required]
        public int Duration { get; set; }
        [Required,
            DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            Display(Name = "Cancellation Date")]
        public DateTime DepartureTime { get; set; }
        [Required,
            DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            Display(Name = "Cancellation Date")]
        public DateTime ArrivalTime { get; set; }
        [Required,
            StringLength(500)]
        public string Description { get; set; } = default!;


        [ForeignKey("TourPackage")]
        public int TourPackageId { get; set; }



        public TourPackage? TourPackage { get; set; }
        public ICollection<TourBooking> TourBooking { get; set; } = new List<TourBooking>();
        public ICollection<TourAvailability> TourAvailabilities { get; set; } = new List<TourAvailability>();
        
        public ICollection<TourImage> TourImage { get; set; } = new List<TourImage>();
    }
}
