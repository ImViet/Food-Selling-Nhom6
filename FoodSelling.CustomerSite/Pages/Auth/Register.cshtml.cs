using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.AuthDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodSelling.CustomerSite.Pages.Auth
{
    public class Register : PageModel
    {
        private readonly IAuth _authService;
        public Register(IAuth authService)
        {
            _authService = authService;
        }
        public async Task<IActionResult> OnPostRegister()
        {
            RegisterDto userRegister = new RegisterDto();
            userRegister.UserName = Request.Form["UserName"];
            userRegister.Email = Request.Form["Email"];
            userRegister.FirstName = Request.Form["FirstName"];
            userRegister.LastName = Request.Form["LastName"];
            userRegister.IdentityCard = Convert.ToInt32(Request.Form["IdentityCard"]);
            userRegister.PhoneNumber = Convert.ToInt32(Request.Form["PhoneNumber"]);
            userRegister.Address = Request.Form["Address"];
            userRegister.Password = Request.Form["Password"];
            userRegister.ConfirmPassword = Request.Form["ConfirmPassword"];
            var result = await _authService.RegisterAsync(userRegister);
            if (result == null)
            {
                return StatusCode(400, new { message = "Unsuccessful" });
            }
            return Redirect("/Auth/Login");
        }
    }
}
