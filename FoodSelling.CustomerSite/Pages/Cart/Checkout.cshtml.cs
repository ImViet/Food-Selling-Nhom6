using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodSelling.CustomerSite.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        private readonly ICart _cartService;
        [BindProperty]
        public List<CartDto> cart { get; set; } = new List<CartDto>();
        public CheckoutModel(ICart cartService)
        {
            _cartService = cartService;
        }
        public ActionResult OnGetAsync()
        {
            cart = _cartService.GetCart();
            return Page();
        }
    }
}