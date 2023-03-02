using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.AuthDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodSelling.CustomerSite.Pages.Auth
{
    public class Login : PageModel
    {
        private readonly IAuth _authService;
        public Login(IAuth authService)
        {
            _authService = authService;
        }
        public async Task<IActionResult> OnPostLogin()
        {
            LoginDto userLogin = new LoginDto();
            userLogin.UserName = Request.Form["UserName"];
            userLogin.Password = Request.Form["Password"];
            var account = await _authService.LoginAsync(userLogin);
            string token = account.Token;
            HttpContext.Session.SetString("JWTToken", token);
            HttpContext.Session.SetString("UserName", account.UserName);
            return Redirect("/Index");
        }

        public async Task<IActionResult> OnGetLogout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Auth/Login");
        }
    }
}
