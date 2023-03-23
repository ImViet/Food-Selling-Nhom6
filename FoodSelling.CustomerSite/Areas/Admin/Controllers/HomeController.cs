using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.CustomerSite.Controllers
{
    [Area("Admin")]
    [Route("/Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IProduct _productService;
        private readonly ICategory _categoryService;
        public HomeController(IProduct productService, ICategory categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<ActionResult> Index()
        {
            var user = HttpContext.Session.GetString("UserName");
            var role = HttpContext.Session.GetString("Role");
            if(user == null || role == null || role != "Admin")
            {
                return Redirect("/Auth/Login");
            }
            var category = await _categoryService.GetAll();
            ViewData["CountCategory"] = category.Count();
            var product = await _productService.CountProduct();
            ViewData["CountProduct"] = product;
            return View();
        }
    }
}