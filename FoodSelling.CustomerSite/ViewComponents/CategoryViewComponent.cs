using Microsoft.AspNetCore.Mvc;
using FoodSelling.CustomerSite.Interfaces;

namespace FoodSelling.CustomerSite.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategory _categoryService;
        public CategoryViewComponent(ICategory category)
        {
            _categoryService = category;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _categoryService.GetAll();
            return View(data);
        }
    }
}