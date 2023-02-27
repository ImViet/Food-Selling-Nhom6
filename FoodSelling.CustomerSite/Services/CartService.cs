using FoodSelling.DTO.Dtos;
using RAShop.CustomerSite.Interfaces;

namespace FoodSelling.CustomerSite.Services
{
    public class CartService : ICart
    {
        public void AddToCart(int productid)
        {
            throw new NotImplementedException();
        }

        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public int CountItem()
        {
            throw new NotImplementedException();
        }

        public List<CartDto>? GetCart()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int productid)
        {
            throw new NotImplementedException();
        }

        public void SaveCartSession(List<CartDto> lst)
        {
            throw new NotImplementedException();
        }
    }
}
