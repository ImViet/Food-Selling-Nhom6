using AutoMapper;
using FoodSelling.Backend.Entities;
using FoodSelling.DTO.Dtos.AuthDtos;
using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;
using FoodSelling.DTO.Dtos.RatingDtos;
using System.Runtime.InteropServices;

namespace FoodSelling.Backend.Utilities
{
    public class AutoMapperProfile : Profile
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
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Products, t => t.MapFrom(src => src.Products));
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.CategoryName, t => t.MapFrom(src => src.Category.CategoryName))
                .ForMember(d => d.Ratings, t => t.MapFrom(src => src.Ratings));
            CreateMap<Rating, RatingDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<EditCategoryDto, Category>();
        }
    }
}
