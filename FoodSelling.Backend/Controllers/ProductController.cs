using FoodSelling.DTO.Dtos;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodSelling.Backend.Interfaces;
using FoodSelling.Backend.Repositories;

namespace FoodSelling.Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<PagingDto<ProductDto>>> GetAllProduct([FromQuery(Name = "sort")] string sortOrder = "0", [FromQuery(Name = "pageCurrent")] int pageNumber = 1)
        {
            return await _productRepository.GetAllProduct(sortOrder, pageNumber, PagingDto<ProductDto>.PAGESIZE);
        }

        [HttpGet]
        public async Task<ActionResult<PagingDto<ProductDto>>> GetProductByCateId([FromQuery(Name = "cateid")] string cateId, [FromQuery(Name = "sort")] string sortOrder = "0", [FromQuery(Name = "pageCurrent")] int pageNumber = 1)
        {
            return await _productRepository.GetProductByCateId(cateId, sortOrder, pageNumber, PagingDto<ProductDto>.PAGESIZE);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }
        [HttpGet()]
        public async Task<ActionResult<PagingDto<ProductDto>>> SearchProducts([FromQuery(Name = "searchstring")] string searchString = "", [FromQuery(Name = "sort")] string sortOrder = "0", [FromQuery(Name = "pageCurrent")] int pageNumber = 1)
        {
            return await _productRepository.SearchProducts(searchString, sortOrder, pageNumber, PagingDto<ProductDto>.PAGESIZE);
        }
        [HttpGet("{id}")]
        public async Task<double> RatingAVG(int id)
        {
            return await _productRepository.RatingAVG(id);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto newProduct)
        {
            return await _productRepository.CreateProduct(newProduct);
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<bool>> DeleteProduct(int productId)
        {
            return await _productRepository.DeleteProduct(productId);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> UpdateProduct([FromBody] EditProductDto newProduct)
        {
            return await _productRepository.UpdateProduct(newProduct);
        }
    }
}
