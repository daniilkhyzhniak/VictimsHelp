using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;

namespace VictimsHelp.PL.Controllers.Api
{
    [ApiController]
    [Route("api/articles")]
    public class ArticleApiController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleApiController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var articles = await _articleService.GetAllAsync();

            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var article = await _articleService.GetByIdAsync(id);

            if (article is null)
            {
                return NotFound($"Article with id={id} was not found.");
            }

            return Ok(article);
        }
    }
}
