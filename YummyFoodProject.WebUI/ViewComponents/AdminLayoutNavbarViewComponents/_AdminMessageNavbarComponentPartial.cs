using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyFoodProject.WebUI.Dtos.MessageDtos;

namespace YummyFoodProject.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _AdminMessageNavbarComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminMessageNavbarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Messages/MessageListByIsReadFalse");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var messages = JsonConvert.DeserializeObject<List<ResultMessageByIsReadFalse>>(jsonData);
                return View(messages);

            }
            return View();
        }
       
    }
}
