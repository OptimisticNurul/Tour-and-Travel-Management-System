using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class TourGuide
    {
        public int TourGuideId { get; set; }
        [Required,
            StringLength(50)]
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        [Required,
            Column(TypeName = "bit")]
        public bool Gender { get; set; }
        [Required,
            StringLength(100)]
        public string Email { get; set; }= default!;
        [Required,
            StringLength(20)]
        public string Phone { get; set; } = default!;
        [Required,
            Column(TypeName = "decimal(10, 2)")]
        public decimal GuideFee { get; set; }
        [Required,
            StringLength(100)]
        public string Image { get; set; } = default!;
        public ICollection<TourPackage> Packages { get; set; } = new List<TourPackage>();
    }
}
