using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
