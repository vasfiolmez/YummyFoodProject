using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _AdminNavbarLeftComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
         }
    }
}
