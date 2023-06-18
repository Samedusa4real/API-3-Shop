using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Dtos.BrandDtos;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using Shop.Data;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpPost("")]
        public IActionResult Create(BrandPostDto brandPostDto)
        {
            Brand brand = new Brand
            {
                Name = brandPostDto.Name,
            };

            _brandRepository.Add(brand);
            _brandRepository.Commit();

            return StatusCode(201, new { brand.Id });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, BrandPutDto brandPutDto)
        {
            Brand brand = _brandRepository.Get(x=>x.Id == id);

            if (brand == null)
                return NotFound();

            brand.Name = brandPutDto.Name;
            _brandRepository.Commit();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Brand brand = _brandRepository.Get(x=>x.Id == id);

            if (brand == null)
                return NotFound();

            _brandRepository.Remove(brand);
            _brandRepository.Commit();

            return NoContent();
        }
            
        [HttpGet("all")]
        public ActionResult<List<BrandGetAllItemDto>> GetAll()
        {
            var data = _brandRepository.GetAllQueryable(x=>true).Select(x=> new BrandGetAllItemDto { Id = x.Id, Name = x.Name}).ToList();
        
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<BrandGetDto> Get(int id)
        {
            var data = _brandRepository.Get(x=>x.Id == id);

            if (data == null)
                return NotFound();

            var brandDto = new BrandGetDto
            {
                Id = id,
                Name = data.Name,
            };

            return Ok(brandDto);
        }
    }
}
