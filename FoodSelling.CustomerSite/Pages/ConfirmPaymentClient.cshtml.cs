using FoodSelling.DTO.Dtos.CustomerSite.MomoDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodSelling.CustomerSite.Pages
{
    public class ConfirmPaymentClientModel : PageModel
    {
        public ActionResult OnGet()
        {
            var statusCode = Request.Query["errorCode"];
            if(statusCode == "0")
            {
                HttpContext.Session.Remove("CountCart");
                HttpContext.Session.Remove("Cart");
                return Redirect("/Index");
            }
                return Redirect("/Error");
        }
    }
}