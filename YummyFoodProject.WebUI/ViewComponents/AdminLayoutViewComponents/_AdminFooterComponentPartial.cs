using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
