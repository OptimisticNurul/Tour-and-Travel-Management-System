using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Travel.Models
{
    public class TourPackage
    {
        public int TourPackageId { get; set; }

        // Multiple IDs for tour transport, hotel, food, and guide
        public List<int> TourTransportIds { get; set; }
        public List<int> TourHotelIds { get; set; }
        public List<int> TourFoodIds { get; set; }
        public List<int> TourGuideIds { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalAmount { get; set; }

        public ICollection<Tour> Tour { get; set; } = new List<Tour>();
    }
}
