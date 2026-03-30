using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebUI.Dtos.ChefDtos;

namespace YummyFoodProject.WebUI.ViewComponents
{
    public class _ChefsDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ChefsDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Chefs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);
                return View(result);
            }
            return View();
        }
    }
}
