using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodSelling.Backend.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public string? Image { get; set; }
        public string? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public IList<Rating>? Ratings { get; set; }
    }
}
