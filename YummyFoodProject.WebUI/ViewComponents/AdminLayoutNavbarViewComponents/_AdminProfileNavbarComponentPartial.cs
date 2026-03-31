using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _AdminProfileNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
