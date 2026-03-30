using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Dtos.ChefDtos;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly YummyFoodContext _context;
        private readonly IMapper _mapper;

        public ChefsController(IMapper mapper, YummyFoodContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList() 
        {
            var values = _context.Chefs.ToList();
            var results = _mapper.Map<List<ResultChefDto>>(values);
            return Ok(results);
        }
        [HttpGet("GetChefById")]
        public IActionResult GetChefById(int id)
        {
            var value = _context.Chefs.FirstOrDefault(x => x.ChefId == id);
            var result = _mapper.Map<GetChefByIdDto>(value);
            return Ok(result);
        }
    }
}
