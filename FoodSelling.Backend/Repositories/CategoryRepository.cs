using AutoMapper;
using FoodSelling.Backend.Data;
using FoodSelling.Backend.Entities;
using FoodSelling.Backend.Interfaces;
using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;
using Microsoft.Data.SqlClient;
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

        public async Task<CategoryDto> CreateCategory(CreateCategoryDto newCategory)
        { 
            var category = _mapper.Map<Category>(newCategory);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<CategoryDto>(category);

            return result;
        }

        public async Task<bool> DeleteCategory(string categoryId)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                return Convert.ToBoolean(await _context.SaveChangesAsync());
            }
            return false;
        }

        public async Task<CategoryDto> UpdateCategory(EditCategoryDto newCategory)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == newCategory.CategoryId);
            if (category != null)
            {
                _context.Categories.Update(category);
                _mapper.Map(newCategory, category);
                await _context.SaveChangesAsync();
            }
            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }
    }
}
