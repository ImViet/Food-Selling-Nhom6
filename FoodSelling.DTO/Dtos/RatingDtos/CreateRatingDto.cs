namespace FoodSelling.DTO.Dtos.RatingDtos
{
    public class CreateRatingDto
    {
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public int Star { get; set; }
        public string? Comment { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
