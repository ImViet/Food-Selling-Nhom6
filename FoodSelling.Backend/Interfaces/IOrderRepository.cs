using FoodSelling.DTO.Dtos.OrderDtos;

namespace FoodSelling.Backend.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>> GetAllOrder();
        Task<OrderDto> CreateOrder(CreateOrderDto order);
    } 
}