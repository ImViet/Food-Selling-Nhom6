using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.AuthDtos;

namespace FoodSelling.CustomerSite.Services
{
    public class AuthService : IAuth
    {
        private readonly IHttpClientFactory _clientFactory;
        public AuthService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public Task<AccountDto> LoginAsync(LoginDto userLogin)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterDto> RegisterAsync(RegisterDto userRegister)
        {
            throw new NotImplementedException();
        }
    }
}
