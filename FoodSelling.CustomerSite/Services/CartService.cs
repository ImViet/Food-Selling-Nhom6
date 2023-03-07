using FoodSelling.DTO.Dtos;
using FoodSelling.CustomerSite.Interfaces;
using Newtonsoft.Json;

namespace FoodSelling.CustomerSite.Services
{
    public class CartService : ICart
    {
        private readonly IProduct _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IProduct productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async void AddToCart(int productid)
        {
            var product = await _productService.GetProductDetail(productid);
            var cart = GetCart();
            var cartItem = cart.Find(p => p.Product.ProductId == productid);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                CartDto newItem = new CartDto()
                {
                    Quantity = 1,
                    Product = product
                };
                cart.Add(newItem);
            }
            SaveCartSession(cart);
        }

        public void ClearCart()
        {
            _httpContextAccessor.HttpContext?.Session.Remove("Cart");
        }

        public int CountItem()
        {
            var listCart = GetCart();
            int count = 0;
            if (listCart.Count() != 0)
            {
                foreach (var item in listCart)
                {
                    count += item.Quantity;
                }
                return count;
            }
            return 0;
        }

        public List<CartDto>? GetCart()
        {
            var jsonCart = _httpContextAccessor.HttpContext?.Session.GetString("Cart");
            if (jsonCart != null)
            {
                return JsonConvert.DeserializeObject<List<CartDto>>(jsonCart);
            }
            return new List<CartDto>();
        }

        public void RemoveItem(int productid)
        {
            var product = _productService.GetProductDetail(productid);
            var cart = GetCart();
            var cartItem = cart.Find(p => p.Product.ProductId == productid);
            cart.Remove(cartItem);
            SaveCartSession(cart);
        }

        public void SaveCartSession(List<CartDto> lst)
        {
            string jsonCart = JsonConvert.SerializeObject(lst);
            _httpContextAccessor.HttpContext?.Session.SetString("Cart", jsonCart);
        }
    }
}
