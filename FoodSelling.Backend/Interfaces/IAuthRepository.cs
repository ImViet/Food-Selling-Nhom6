using FoodSelling.DTO.Dtos.AuthDtos;
using FoodSelling.DTO.Dtos.UserDtos;

namespace FoodSelling.Backend.Interfaces
{
    public interface IAuthRepository
    {
        Task<AccountDto> LoginAsync(LoginDto userLogin);
        Task<RegisterDto> RegisterAsync(RegisterDto userRegister);
        Task<bool> CheckUserAvalable(string userName);
        Task<UserDto> GetMe(string userName);
    }
}
