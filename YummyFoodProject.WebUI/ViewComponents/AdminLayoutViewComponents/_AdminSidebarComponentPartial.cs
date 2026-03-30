using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
