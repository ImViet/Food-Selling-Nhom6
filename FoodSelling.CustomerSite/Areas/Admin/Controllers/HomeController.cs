using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = HttpContext.Session.GetString("UserName");
            var role = HttpContext.Session.GetString("Role");
            if(user == null || role == null || role != "Admin")
            {
                return Redirect("/Auth/Login");
            }
            return View();
        }
    }
}