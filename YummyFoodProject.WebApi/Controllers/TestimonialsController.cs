using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Dtos.TestimonialDtos;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly YummyFoodContext _context;
        private readonly IMapper _mapper;
        public TestimonialsController(YummyFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            var results = _mapper.Map<List<ResultTestimonialDto>>(values);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdTestimonial(int id)
        {
            var value = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == id);
            if (value == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<ResultTestimonialDto>(value);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Testimonial başarılı bir şekilde eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == updateTestimonialDto.TestimonialId);
            if (value == null)
            {
                return NotFound();
            }
            var testimonial = _mapper.Map(updateTestimonialDto, value);
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Testimonial başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Testimonial başarılı bir şekilde silindi.");
        }
    }
}
