using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
