using FoodSelling.CustomerSite.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.CustomerSite.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cartService;
        public CartController(ICart cartService)
        {
            _cartService = cartService;
        }
        public IActionResult CheckCart()
        {
            var cart = _cartService.GetCart();
            var result = cart.Count();
            if(result == 0)
                return new JsonResult(new { result = false});
            return new JsonResult(new { result = true});
        }
        public IActionResult AddToCartUsingAjax(int id)
        {
            _cartService.AddToCart(id);
            HttpContext.Session.SetString("CountCart", _cartService.CountItem().ToString());
            return new JsonResult(new { CountItem = HttpContext.Session.GetString("CountCart") });
        }
        public IActionResult IncreaseItemInCart(int id, int quantity)
        {
            var cart = _cartService.GetCart();
            var item = cart.Find(p => p.Product.ProductId == id);
            item.Quantity = quantity;
            _cartService.SaveCartSession(cart);
            HttpContext.Session.SetString("CountCart", _cartService.CountItem().ToString());
            return new JsonResult(
                new
                {
                    Id = id,
                    CountItem = HttpContext.Session.GetString("CountCart"),
                    Total = item.Total,
                    TotalToPay = cart.Sum(p => p.Total)
                }
            );
        }
        public IActionResult DeleteItemInCart(int id)
        {
            var cart = _cartService.GetCart();
            _cartService.RemoveItem(id);
            HttpContext.Session.SetString("CountCart", _cartService.CountItem().ToString());
            return new JsonResult(
                new {
                    CountItem = HttpContext.Session.GetString("CountCart"),
                    TotalToPay = cart.Sum(p => p.Total)
                }
            );
        }
    }
}