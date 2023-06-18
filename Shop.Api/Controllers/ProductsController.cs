using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Dtos.ProductDtos;
using Shop.Core.Entities;
using Shop.Core.Repositories;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("")]
        public IActionResult Create(ProductPostDto productPostDto)
        {
            Product product = new Product
            {
                Name = productPostDto.Name,
                Price = productPostDto.Price,
                DiscountPercent = productPostDto.DiscountPercent,
                BrandId = productPostDto.BrandId,
            };

            _productRepository.Add(product);
            _productRepository.Commit();

            return StatusCode(201, new { product.Id });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, ProductPutDto productPutDto)
        {
            Product product = _productRepository.Get(x=>x.Id == id);

            if (product == null)
                return NotFound();

            product.Name = productPutDto.Name;
            product.Price = productPutDto.Price;
            product.DiscountPercent = productPutDto.DiscountPercent;
            product.BrandId = productPutDto.BrandId;

            _productRepository.Commit();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _productRepository.Get(x => x.Id == id);

            if (product == null)
                return NotFound();

            _productRepository.Remove(product);
            _productRepository.Commit();

            return NoContent();
        }

        [HttpGet("all")]
        public ActionResult<List<ProductGetAllItem>> GetAll()
        {
            var data = _productRepository.GetAllQueryable(x=>true,"Brand").Select(x=>new ProductGetAllItem { Id = x.Id, Name = x.Name, Price = x.Price, DiscountPercent = x.DiscountPercent, Brand = new BrandInProductsDto { Id = x.BrandId, Name = x.Brand.Name } }).ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductGetDto> Get(int id)
        {
            var data = _productRepository.Get(x=>x.Id == id);

            if (data == null)
                return NotFound();

            var productDto = new ProductGetDto
            {
                Id = id,
                Name = data.Name,
                Price = data.Price,
                DiscountPercent = data.DiscountPercent,
                Brand = new BrandInProductDto
                {
                    Id = data.BrandId,
                    Name = data.Brand.Name,
                }
            };

            return Ok(productDto);
        }
    }
}
