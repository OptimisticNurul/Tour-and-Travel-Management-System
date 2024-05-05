using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class TourFood
    {
        public int TourFoodId { get; set; }
        [Required,
            StringLength(100)]
        public string Name { get; set; } = default!;
        [Required,
            StringLength(100)]
        public string Type { get; set; } = default!;
        [Required,
            StringLength(500)]
        public string Description { get; set; } = default!;
        [Required,
            Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public ICollection<TourPackage> Packages { get; set; } = new List<TourPackage>();
    }
}
