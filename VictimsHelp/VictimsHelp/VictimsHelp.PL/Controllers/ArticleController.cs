using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Models;

namespace VictimsHelp.PL.Controllers
{
    [Route("articles")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var articles = await _articleService.GetAllAsync();

            return View(articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var article = await _articleService.GetByIdAsync(id);

            if (article is null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(article);
        }

        [HttpGet("new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create(ArticleModel model)
        {
            if (ModelState.IsValid)
            {
                await _articleService.CreateAsync(model);

                return RedirectToAction("List");
            }

            return View(model);
        }

        [HttpGet("{id}/update")]
        public IActionResult Edit(Guid id)
        {
            var article = _articleService.GetByIdAsync(id);

            if (article is null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(article);
        }
        
        [HttpPost("{id}/update")]
        public async Task<IActionResult> Edit(ArticleModel model)
        {
            if (ModelState.IsValid)
            {
                await _articleService.EditAsync(model);

                return RedirectToAction("Details", new { id = model.Id });
            }

            return View(model);
        }

        [HttpGet("{id}/remove")]
        public IActionResult Delete(Guid id)
        {
            var article = _articleService.GetByIdAsync(id);

            if (article is null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(article);
        }

        [HttpPost("{id}/remove")]
        public async Task<IActionResult> Delete(ArticleModel model)
        {
            await _articleService.DeleteByIdAsync(model.Id);

            return RedirectToAction("List");
        }
    }
}
