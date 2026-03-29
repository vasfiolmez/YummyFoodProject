using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyFoodProject.WebUI.Dtos.ProductDtos;

namespace YummyFoodProject.WebUI.ViewComponents
{
    public class _MenuProductDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MenuProductDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(responseData);
                return View(values);
            }
            return View();
        }
    }
}
