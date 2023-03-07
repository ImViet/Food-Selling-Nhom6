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
        public IActionResult AddToCartUsingAjax(int id)
        {
            _cartService.AddToCart(id);
            HttpContext.Session.SetString("CountCart", _cartService.CountItem().ToString());
            return new JsonResult(new { CountItem = HttpContext.Session.GetString("CountCart") });
        }
    }
}