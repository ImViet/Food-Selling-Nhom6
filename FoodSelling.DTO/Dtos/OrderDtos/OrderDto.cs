namespace FoodSelling.DTO.Dtos.OrderDtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShipAddress { get; set; } 
    }
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
    }
    public class CreateOrderDto
    {
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShipAddress { get; set; }
        public List<OrderDetailDto> OrderDetail { get; set; }
    }
}