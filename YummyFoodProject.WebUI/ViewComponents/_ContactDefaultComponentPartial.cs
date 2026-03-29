using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents
{
    public class _ContactDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
