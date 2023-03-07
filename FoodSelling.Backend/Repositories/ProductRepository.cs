using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using FoodSelling.Backend.Data;
using FoodSelling.Backend.Entities;
using FoodSelling.Backend.Interfaces;
using FoodSelling.DTO.Dtos;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;
using Microsoft.EntityFrameworkCore;

namespace FoodSelling.Backend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FoodSellingDbContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(FoodSellingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagingDto<ProductDto>> GetAllProduct(string sortOrder, int pageNumber, int pageSize)
        {
            //Query product
            var productsQuery = _context.Products.AsQueryable();
            //Sort
            productsQuery = Sorting(productsQuery, sortOrder);

            var countProduct = await productsQuery.CountAsync();

            //Paging
            var products = await productsQuery.Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .Include(x => x.Category)
                                            .Include(x => x.Ratings)
                                            .ToListAsync();
            var listProductDto = _mapper.Map<List<ProductDto>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDto<ProductDto>.PAGESIZE);
            return new PagingDto<ProductDto> { TotalPages = totalPages, Items = listProductDto };
        }

        public async Task<PagingDto<ProductDto>> GetProductByCateId(string cateId, string sortOrder, int pageNumber, int pageSize)
        {
            //Query product
            var productsQuery = _context.Products.Where(c => c.Category.CategoryId == cateId);
            //Sort
            productsQuery = Sorting(productsQuery, sortOrder);

            var countProduct = await productsQuery.CountAsync();

            //Paging
            var products = await productsQuery.Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .Include(x => x.Category)
                                            .Include(x => x.Ratings)
                                            .ToListAsync();
            var listProductDto = _mapper.Map<List<ProductDto>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDto<ProductDto>.PAGESIZE);
            return new PagingDto<ProductDto> { TotalPages = totalPages, Items = listProductDto };
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            //Query
            var query = await _context.Products.Where(x => x.ProductId == id).Include(x => x.Ratings).Include(x => x.Category).FirstOrDefaultAsync();
            var productDto = _mapper.Map<ProductDto>(query);
            return productDto;
        }

        public async Task<PagingDto<ProductDto>> SearchProducts(string searchString, string sortOrder, int pageNumber, int pageSize)
        {
            //Convert searchstring
             var str = ConvertToUnSign(searchString);
            //Query product
            var productsQuery = _context.Products.Where(delegate (Product p)
                                        {
                                            if(ConvertToUnSign(p.ProductName).IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) >= 0)
                                                return true;
                                            else
                                                return false;
                                        }).AsQueryable();
            //Sort
            productsQuery = Sorting(productsQuery, sortOrder);

            var countProduct = productsQuery.Count();

            //Paging
            var products = productsQuery.Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .Include(x => x.Category)
                                            .Include(x => x.Ratings)
                                            .ToList();
            var listProductDto = _mapper.Map<List<ProductDto>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDto<ProductDto>.PAGESIZE);
            return new PagingDto<ProductDto> { TotalPages = totalPages, Items = listProductDto };
        }
        public async Task<double> RatingAVG(int id)
        {
            double ratingAvg = 0;
            var ratingProduct = await _context.Ratings.FirstOrDefaultAsync(x => x.ProductId == id);
            if (ratingProduct != null)
            {
                ratingAvg = await _context.Products.Where(p => p.ProductId == id).Select(r => r.Ratings.Average(s => s.Star)).FirstOrDefaultAsync();
            }
            else
            {
                ratingAvg = 0;
            }
            return ratingAvg;
        }
        private IQueryable<Product> Sorting(IQueryable<Product> products, string sortOrder)
        {
            switch (sortOrder)
            {
                case "price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "name":
                    products = products.OrderBy(p => p.ProductName);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.ProductName);
                    break;
                default:
                    products = products.OrderBy(p => p.ProductId);
                    break;
            }
            return products;
        }
        private string ConvertToUnSign(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            return str2;
        }
    }
}
