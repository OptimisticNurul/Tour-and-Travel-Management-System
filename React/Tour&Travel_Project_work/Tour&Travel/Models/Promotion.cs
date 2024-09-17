using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; } = default!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = default!;

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Discount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int RemainingUses { get; set; }

        public ICollection<TourBooking> TourBookings { get; set; } = new List<TourBooking>();
    }
}
