using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents
{
    public class _MenuDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
