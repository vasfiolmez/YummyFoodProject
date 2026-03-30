using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Dtos.FoodEventsDtos;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodEventsController : ControllerBase
    {
        private readonly YummyFoodContext _context;
        private readonly IMapper _mapper;

        public FoodEventsController(YummyFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult FoodEventsList()
        {
            var values = _context.FoodEvents.ToList();
            var results = _mapper.Map<List<ResultFoodEventsDto>>(values);
            return Ok(results);
        }
        [HttpGet("GetFoodEventsById")]
        public IActionResult GetFoodEventsById(int id)
        {
            var value = _context.FoodEvents.FirstOrDefault(x => x.FoodEventId == id);
            if (value == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<GetFoodEventsById>(value);
            return Ok(result);
        }
    }
}
