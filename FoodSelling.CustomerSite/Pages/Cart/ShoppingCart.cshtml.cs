using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodSelling.CustomerSite.Pages.Cart
{
    public class ShoppingCartModel : PageModel
    {
        private readonly ICart _cartService;
        [BindProperty]
        public List<CartDto> cart { get; set; } = new List<CartDto>();
        public ShoppingCartModel(ICart cartService)
        {
            _cartService = cartService;
        }
        public ActionResult OnGetAsync()
        {
            cart = _cartService.GetCart();
            return Page();
        }
        public IActionResult OnGetAddToCart(int id)
        {
            _cartService.AddToCart(id);
            HttpContext.Session.SetString("CountCart", _cartService.CountItem().ToString());
            return RedirectToPage("ShoppingCart");
        }
        public IActionResult OnGetRemoveItem(int id)
        {
            _cartService.RemoveItem(id);
            HttpContext.Session.SetString("CountCart", _cartService.CountItem().ToString());
            return RedirectToPage("ShoppingCart");
        }
    }
}
