using Bogus;
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
        private readonly BookGenerator _bookGenerator;
        public BookController(BookGenerator bookGenerator)
        {
            _bookGenerator = bookGenerator;
        }

        [HttpGet("{language:int}")]
        public ActionResult Index(LanguageEnum language = LanguageEnum.en)
        {
            var books = _bookGenerator.GenerateList(language, 1, 1);
            return Ok(books);
        }

        [HttpGet("{seed:int}&{page:int}&{likes:float}&{reviews:float}&{language:int}")]
        public ActionResult Index(int seed,int page, float likes = 1, float reviews = 1, LanguageEnum language = LanguageEnum.en)
        {
            Randomizer.Seed = new Random(seed+page);
            var books = _bookGenerator.GenerateList(language,likes,reviews,page);
            return Ok(books);
        }

       
    }
}
