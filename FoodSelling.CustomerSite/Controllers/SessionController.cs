using FoodSelling.CustomerSite.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.CustomerSite.Controllers
{
    public class SessionController : Controller
    {
        public JsonResult CheckUserLogin()
        {
            var userLogin = HttpContext.Session.GetString("UserName");
            if (userLogin == null)
            {
                return new JsonResult(new
                {
                    result = false
                });
            }
            return new JsonResult(new
            {
                result = true
            });
        }
    }
}