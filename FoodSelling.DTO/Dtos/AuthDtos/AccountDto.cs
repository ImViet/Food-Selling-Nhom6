﻿namespace FoodSelling.DTO.Dtos.AuthDtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }

    }
}