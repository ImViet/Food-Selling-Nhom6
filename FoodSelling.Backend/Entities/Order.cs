using System.ComponentModel.DataAnnotations;

namespace FoodSelling.Backend.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShipAddress { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
