using FoodSelling.DTO.Dtos;

namespace RAShop.CustomerSite.Interfaces
{
    public interface ICart 
    {
        List<CartDto>? GetCart();
        void AddToCart(int productid);
        void RemoveItem(int productid);
        void ClearCart();
        void SaveCartSession(List<CartDto> lst);
        int CountItem();
    }
}