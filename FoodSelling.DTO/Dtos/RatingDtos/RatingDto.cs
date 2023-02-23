namespace FoodSelling.DTO.Dtos.RatingDtos
{
    public class RatingDto
    {
        public int RatingId { get; set; }
        public string UserName { get; set; }
        public int Star { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
