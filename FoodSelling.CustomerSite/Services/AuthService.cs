﻿using System.Text;
using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.AuthDtos;
using Newtonsoft.Json;

namespace FoodSelling.CustomerSite.Services
{
    public class AuthService : IAuth
    {
        private readonly IHttpClientFactory _clientFactory;
        public AuthService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<AccountDto> LoginAsync(LoginDto userLogin)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/auth/login";
            var jsonString = JsonConvert.SerializeObject(userLogin);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode) return null;
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<AccountDto>(jsonData);
            return data;
        }

        public async Task<RegisterDto> RegisterAsync(RegisterDto userRegister)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/auth/register";
            var jsonString = JsonConvert.SerializeObject(userRegister);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode) return null;
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<RegisterDto>(jsonData);
            return data;
        }
    }
}
