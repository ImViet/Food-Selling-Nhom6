using AutoMapper;
using FoodSelling.Backend.Entities;
using FoodSelling.Backend.Interfaces;
using FoodSelling.DTO.Dtos.AuthDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RAShop.Backend.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager,
         RoleManager<Role> roleManager, IConfiguration config, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _mapper = mapper;
        }

        public async Task<AccountDto> LoginAsync(LoginDto userLogin)
        {
            var user = await _userManager.FindByNameAsync(userLogin.UserName);
            if (user == null)
            {
                throw new Exception("Cannot find this user");
            }
            var result = await _signInManager.PasswordSignInAsync(user, userLogin.Password, true, true);
            if (!result.Succeeded)
            {
                return null;
            }
            string token = CreateToken(user);
            var account = _mapper.Map<AccountDto>(user);
            account.Token = token;
            return account;
        }
        public async Task<RegisterDto> RegisterAsync(RegisterDto userRegister)
        {
            var user = _mapper.Map<User>(userRegister);
            user.Id = Guid.NewGuid().ToString();
            user.Role = "User";
            var result = await _userManager.CreateAsync(user, userRegister.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            return userRegister;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("UserName", user.UserName),
                new Claim("IdentityCard", user.IdentityCard.ToString()),
                new Claim("Role", user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
