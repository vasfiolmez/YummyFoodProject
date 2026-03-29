using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyFoodProject.WebUI.Dtos.CategoryDtos;

namespace YummyFoodProject.WebUI.ViewComponents
{
    public class _MenuCategoryDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MenuCategoryDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(responseData);
                return View(values);
            }
            return View();
        }
    }
}
