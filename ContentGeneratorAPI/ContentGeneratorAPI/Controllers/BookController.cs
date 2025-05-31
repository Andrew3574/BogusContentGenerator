using ContentGeneratorAPI.Models;
using ContentGeneratorAPI.Services.Generators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace ContentGeneratorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private ConcurrentBag<Book> _books = new ConcurrentBag<Book>();
        private readonly BookGenerator _bookGenerator;
        public BookController(BookGenerator bookGenerator)
        {
            _bookGenerator = bookGenerator;
        }

        [HttpGet]
        public ActionResult Index(float likes, float reviews, LanguageEnum language = LanguageEnum.en)
        {
            var books = _bookGenerator.GenerateList(language,likes,reviews);
            foreach (var item in books)
            {
                _books.Add(item);
            }
            return Ok(_books);
        }

       
    }
}
