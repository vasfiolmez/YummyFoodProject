using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
