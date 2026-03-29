using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents
{
    public class _ChefsDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
