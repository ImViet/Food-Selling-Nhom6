using FoodSelling.DTO.Dtos.AuthDtos;

namespace FoodSelling.Backend.Interfaces
{
    public interface IAuthRepository
    {
        Task<AccountDto> LoginAsync(LoginDto userLogin);
        Task<RegisterDto> RegisterAsync(RegisterDto userRegister);
        Task<bool> CheckUserAvalable(string userName);
    }
}
