using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class TourTransport
    {
        public int TourTransportId { get; set; }
        [Required,
            StringLength(100),
            Display(Name = "Tour Transport Name")]
        public string TourTransportName { get; set; } = default!;
        [Required,
            DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required,
            Column(TypeName = "decimal(10, 2)"),
            Display(Name = "Rent Per Person")]
        public decimal RentPerPerson { get; set; }
        public ICollection<TourPackage> Packages { get; set; } = new List<TourPackage>();
    }
}
