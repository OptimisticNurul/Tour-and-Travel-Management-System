using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tour_Travel.Models
{
    public class Review
    {
        public int Reviewid { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required,
            DataType(DataType.DateTime),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        [Required,
            StringLength(500)]
        public string Comment { get; set; } = default!;
        public User? User { get; set; }
    }
}
