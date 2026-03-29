using Microsoft.AspNetCore.Mvc;

namespace YummyFoodProject.WebUI.ViewComponents
{
    public class _AboutDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
