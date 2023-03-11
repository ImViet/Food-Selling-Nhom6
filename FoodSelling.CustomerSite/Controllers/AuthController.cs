using FoodSelling.CustomerSite.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.CustomerSite.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuth _authService;
        public AuthController(IAuth authService)
        {
            _authService = authService;
        }
        public async Task<bool> CheckUserAvailable(string userName)
        {
            var result = await _authService.CheckUserAvailable(userName);
            if (result == true)
                return false;
            else
                return true;
        }
    }
}