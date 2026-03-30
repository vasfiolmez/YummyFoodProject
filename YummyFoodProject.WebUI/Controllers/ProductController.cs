using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductList()
        {
            return View();
        }
    }
}
