using FoodSelling.DTO.Dtos.AuthDtos;
using FoodSelling.DTO.Dtos.UserDtos;

namespace FoodSelling.CustomerSite.Interfaces
{
    public interface IAuth
    {
        Task<AccountDto> LoginAsync(LoginDto userLogin);
        Task<RegisterDto> RegisterAsync(RegisterDto userRegister);
        Task<bool> CheckUserAvailable(string userName);
        Task<UserDto> GetMe(string userName);
    }
}