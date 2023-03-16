using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodSelling.CustomerSite.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        private readonly ICart _cartService;
        private readonly IAuth _authService;
        [BindProperty]
        public List<CartDto> cart { get; set; } = new List<CartDto>();
        public CheckoutModel(ICart cartService, IAuth authService)
        {
            _cartService = cartService;
            _authService = authService;
        }
        public async Task<ActionResult> OnGetAsync()
        {
            cart = _cartService.GetCart();
            var userName = HttpContext.Session.GetString("UserName");
            var user = await _authService.GetMe(userName);
            ViewData["user"] = user;
            return Page();
        }
    }
}