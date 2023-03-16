using FoodSelling.Backend.Interfaces;
using FoodSelling.DTO.Dtos.AuthDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CheckUserAvailable([FromBody]string userName)
        {
            var result = await _authRepository.CheckUserAvalable(userName);
            if(result == false)
            {
                return false;
            }
            return true;
        }
        [HttpPost]
        public async Task<ActionResult<AccountDto>> LoginAsync(LoginDto userLogin)
        {
            var account = await _authRepository.LoginAsync(userLogin);
            if (account == null)
            {
                return BadRequest("Username or Password is incorrect. Please try again");
            }
            return Ok(account);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterDto userRegister)
        {
            if (userRegister.Password != userRegister.ConfirmPassword)
            {
                return BadRequest("Password is incorrect with confirmpassword");
            }
            var result = await _authRepository.RegisterAsync(userRegister);
            if (result == null)
            {
                return BadRequest("Register is unsuccessful");
            }
            return Ok(userRegister);
        }
        [HttpPost]
        public async Task<ActionResult> GetMe([FromBody] string userName)
        {
            var result = await _authRepository.GetMe(userName);
            if(result == null)
            {
                return BadRequest("User not available");
            }
            return Ok(result);
        }
    }
}
