using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Dtos.ServiceDtos;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly YummyFoodContext _context;

        public ServicesController(IMapper mapper, YummyFoodContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var services = _context.Services.ToList();
            return Ok(services);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdServiceDto(int id)
        {
            var service = _context.Services.FirstOrDefault(x => x.ServiceId == id);
            if (service == null)
            {
                return NotFound("Hizmet bulunamadı");
            }

            var serviceDto = _mapper.Map<ResultServiceDto>(service);
            return Ok(service);
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {
            var service = _mapper.Map<Service>(createServiceDto);
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Hizmet başarılı bir şekilde eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            var value = _context.Services.FirstOrDefault(x => x.ServiceId == updateServiceDto.ServiceId);

            if (value == null)
            {
                return NotFound("Hizmet bulunamadı");
            }

            var service = _mapper.Map(updateServiceDto, value);
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Hizmet başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.FirstOrDefault(x => x.ServiceId == id);
            if (value == null)
            {
                return NotFound("Hizmet bulunamadı");
            }
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Hizmet başarılı bir şekilde silindi.");
        }
    }
}
