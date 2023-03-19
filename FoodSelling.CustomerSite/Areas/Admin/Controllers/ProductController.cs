using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;
using FoodSelling.DTO.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productService;
        public ProductController(IProduct productService)
        {
            _productService = productService;
        }
        public async Task<ActionResult> Index(string sortOrder = "0", int pageCurrent = 1)
        {
            // var user = HttpContext.Session.GetString("UserName");
            // var role = HttpContext.Session.GetString("Role");
            // if(user == null || role != "Admin")
            // {
            //     return Redirect("/Auth/Login");
            // }
            var products = await _productService.GetAll(sortOrder, pageCurrent);
            ViewData["products"] = products.Items;
            return View();
        }

        public async Task<ActionResult> CreateProduct()
        {
            // CreateProductDto product = new CreateProductDto();
            // product.ProductName = Request.Form["ProductName"];
            // product.Price = Convert.ToInt32(Request.Form["Price"]);
            // product.CreatedDate = DateTime.Now;
            // product.UpdatedDate = new DateTime();
            // product.Description = Request.Form["Description"];
            // product.Unit = Request.Form["Unit"];
            // product.Image = null;
            // product.CategoryId = Request.Form["CategoryId"];
            // var result = _productService.CreateProduct(product);
            return View();
        }
    }
}