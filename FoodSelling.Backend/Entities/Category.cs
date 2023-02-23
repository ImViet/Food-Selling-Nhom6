using System.ComponentModel.DataAnnotations;

namespace FoodSelling.Backend.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        public string? CategoryImg { get; set; }
        public string? Description { get; set; }
        public IList<Product>? Products { get; set; }
    }
}
