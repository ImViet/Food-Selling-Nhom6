using AutoMapper;
using FoodSelling.Backend.Entities;
using FoodSelling.DTO.Dtos.AuthDtos;
using System.Runtime.InteropServices;

namespace FoodSelling.Backend.Utilities
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<RegisterDto, User>();
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<User, AccountDto>()
                .ForMember(d => d.Token, t => t.Ignore());
        }
    }
}
