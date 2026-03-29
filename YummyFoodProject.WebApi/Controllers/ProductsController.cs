using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Dtos.ProductDtos;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly YummyFoodContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductDto> _createValidator;
        private readonly IValidator<UpdateProductDto> _updateValidator;


        public ProductsController(YummyFoodContext context, IMapper mapper, IValidator<UpdateProductDto> updateValidator, IValidator<CreateProductDto> createValidator)
        {
            _context = context;
            _mapper = mapper;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var result = _createValidator.Validate(createProductDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var value = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Ürün başarılı bir şekilde Eklendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdProduct(int id)
        {
            var value = _context.Products.Find(id);
            if (value == null)
            {
                return NotFound("Ürün bulunamadı.");
            }
            var productDto = _mapper.Map<ResultProductDto>(value);
            return Ok(productDto);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var result = _updateValidator.Validate(updateProductDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var value = _context.Products.FirstOrDefault(p => p.ProductId == updateProductDto.ProductId);
            if (value == null)
            {
                return NotFound("Ürün bulunamadı.");
            }

            var product = _mapper.Map(updateProductDto, value);
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok("Ürün başarılı bir şekilde güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            if (value == null)
            {
                return NotFound("Ürün bulunamadı.");
            }
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Ürün başarılı bir şekilde silindi.");
        }

        [HttpGet("ProductListWithCategoryName")]
        public IActionResult ProductListWithCategoryName()
        {
            var value = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(value));
        }
    }
}
