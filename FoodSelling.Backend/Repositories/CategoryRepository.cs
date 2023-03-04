using AutoMapper;
using FoodSelling.Backend.Data;
using FoodSelling.Backend.Interfaces;
using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;
using Microsoft.EntityFrameworkCore;

namespace FoodSelling.Backend.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly FoodSellingDbContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(FoodSellingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get all category
        public async Task<List<CategoryDto>> GetAllCategory()
        {
            var categories = await _context.Categories.Include(p => p.Products).ToListAsync();
            var listCateDto = _mapper.Map<List<CategoryDto>>(categories);
            return listCateDto;
        }
    }
}
