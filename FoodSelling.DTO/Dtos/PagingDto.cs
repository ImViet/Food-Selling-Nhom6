namespace FoodSelling.DTO.Dtos
{
    public class PagingDto<T>
    {
        public int TotalPages { get; set; }
        public const int PAGESIZE = 8;
        public List<T>? Items { get; set; }
    }
}
