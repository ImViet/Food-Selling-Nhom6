using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.CustomerSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryService;
        public CategoryController(ICategory categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ActionResult> Index()
        {
            var user = HttpContext.Session.GetString("UserName");
            var role = HttpContext.Session.GetString("Role");
            if(user == null || role != "Admin")
            {
                return Redirect("/Auth/Login");
            }
            var categories = await _categoryService.GetAll();
            ViewData["categories"] = categories;
            return View();
        }
    }
}