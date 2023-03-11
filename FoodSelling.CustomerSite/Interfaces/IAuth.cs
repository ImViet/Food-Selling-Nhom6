using FoodSelling.DTO.Dtos.AuthDtos;


namespace FoodSelling.CustomerSite.Interfaces
{
    public interface IAuth
    {
        Task<AccountDto> LoginAsync(LoginDto userLogin);
        Task<RegisterDto> RegisterAsync(RegisterDto userRegister);
        Task<bool> CheckUserAvailable(string userName);
    }
}