using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyFoodProject.WebUI.Dtos.MessageDtos;

namespace YummyFoodProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminNavbarComponentPartial:ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
