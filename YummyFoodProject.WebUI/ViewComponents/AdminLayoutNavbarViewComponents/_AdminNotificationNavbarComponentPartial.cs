using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyFoodProject.WebUI.Dtos.NotificationDtos;

namespace YummyFoodProject.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _AdminNotificationNavbarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminNotificationNavbarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // API adresini kendi Notification controller'ına göre ayarla
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Notifications");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var notifications = JsonConvert.DeserializeObject<List<ResultNotificationsDto>>(jsonData);
                return View(notifications);
            }

            return View();
        }
    }
}
