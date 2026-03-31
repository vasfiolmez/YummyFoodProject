using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YummyFoodProject.WebUI.Dtos.CategoryDtos;

namespace YummyFoodProject.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // API URL'sini tek bir yerden yönetmek kod tekrarını önler
        private readonly string _apiUrl = "https://localhost:7052/api/Categories";

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #region Listeleme İşlemi (GET)
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }

            // API'den veri gelmezse boş liste döndürerek sayfanın patlamasını önleriz
            return View(new List<ResultCategoryDto>());
        }
        #endregion

        #region Ekleme İşlemi (CREATE)
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();

            // Veriyi JSON formatına çeviriyoruz
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync(_apiUrl, stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }

            // İşlem başarısız olursa aynı sayfaya geri döner
            return View();
        }
        #endregion

        #region Silme İşlemi (DELETE)
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_apiUrl}?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }

            // Hata durumunda da listeye yönlendirebilir veya hata mesajı gösterebiliriz
            return RedirectToAction("CategoryList");
        }
        #endregion

        #region Güncelleme İşlemi (UPDATE)
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl}/GetCategory?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                // Güncellenecek veriyi API'den çekip inputların içini doldurmak için View'a gönderiyoruz
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(value);
            }
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();

            // Değişiklik yapılan veriyi tekrar JSON'a çeviriyoruz
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Güncelleme işleminde PutAsync kullanılır
            var responseMessage = await client.PutAsync(_apiUrl, stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View(updateCategoryDto);
        }
        #endregion
    }
}
