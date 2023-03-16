using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.UserDtos;
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

        public async Task<IActionResult> GetMe(string userName)
        {
            var user = await _authService.GetMe(userName);
            if(user == null)
            {
                return new JsonResult(new UserDto());
            }
            return new JsonResult(new{
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                IdentityCard = user.IdentityCard,
            });
        }
    }
}