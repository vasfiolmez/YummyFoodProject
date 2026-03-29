using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Dtos.FeatureDtos;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly YummyFoodContext _context;

        public FeaturesController(IMapper mapper, YummyFoodContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            var featuresDto = _mapper.Map<List<ResultFeatureDto>>(values);
            return Ok(featuresDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdFeature(int id)
        {
            var value = _context.Features.FirstOrDefault(f => f.FeatureId == id);
            if (value == null)
            {
                return NotFound();
            }
            var featureDto = _mapper.Map<GetByIdFeatureDto>(value);
            return Ok(featureDto);
        }
    
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.FirstOrDefault(f => f.FeatureId == id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _context.Features.FirstOrDefault(f => f.FeatureId == updateFeatureDto.FeatureId);
            if (value == null)
            {
                return NotFound();
            }
            var feature = _mapper.Map(updateFeatureDto, value);
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Tamamlandı.");
        }
    }
}
