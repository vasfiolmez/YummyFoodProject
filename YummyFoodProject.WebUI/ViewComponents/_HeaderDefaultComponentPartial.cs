using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents
{
    public class _HeaderDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
