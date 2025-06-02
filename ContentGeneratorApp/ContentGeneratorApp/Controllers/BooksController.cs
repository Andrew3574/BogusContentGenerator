using ContentGeneratorAPI.Models;
using ContentGeneratorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Globalization;

namespace ContentGeneratorAPI.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClient _httpClient;
        public BooksController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7272/api/Book/");
        }

        [HttpGet]
        public async Task<IActionResult> Index(LanguageEnum language = LanguageEnum.en)
        {
            var books = await _httpClient.GetFromJsonAsync<List<Book>>($"{(int)language}");
            return View(books);
        }

        [HttpGet]
        public async Task<JsonResult> LoadMore(int seed,int page, float likes = 1, float reviews = 1, LanguageEnum language = LanguageEnum.en)
        {
            var books = await _httpClient.GetFromJsonAsync<List<Book>>($"{seed}&{page}&{likes}&{reviews.ToString(CultureInfo.InvariantCulture)}&{(int)language}");
            return Json(books);
                
        }

       
    }
}
