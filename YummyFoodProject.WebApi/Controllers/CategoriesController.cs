using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly YummyFoodContext _context;

        public CategoriesController(YummyFoodContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("KAtegori ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori güncelleme işlemi başarılı");
        }
    }
}
