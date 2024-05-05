using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tour_Travel.ViewModels
{
    public class TourImageVM
    {
        public int TourId { get; set; }
        public string TourName { get; set; } = default!;
        public string Destination { get; set; } = default!;
        public int Duration { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Description { get; set; } = default!;

        //public decimal Price { get; set; }
        public int TourPackageId { get; set; }
        


        public DateTime Date { get; set; }
        public int AvailableSlots { get; set; }


        public List<IFormFile>? ImageFile { get; set; }

    }
}
