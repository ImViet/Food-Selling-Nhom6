using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodSelling.Backend.Entities
{
    public class Rating
    {
        public int RatingId { get; set; }
        public string UserName { get; set; }
        [Required]
        public int Star { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
}
