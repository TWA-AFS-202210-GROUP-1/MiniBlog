using MiniBlog.Services;

namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleStore _articleStore;
        private readonly IUserStore _userStore;
        private readonly IArticleService _articleService;

        public ArticleController(IArticleStore articleStore, IUserStore userStore, IArticleService articleService)
        {
            _articleStore = articleStore;
            _userStore = userStore;
            _articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return _articleService.GetAllArticles();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            var createdArticle = _articleService.CreateArticle(article);
            if (createdArticle == null)
            {
                return BadRequest();
            }

            return Created($"/article/{createdArticle.Id}", createdArticle);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var foundArticle = _articleService.GetArticle(id);
            if (foundArticle == null)
            {
                return BadRequest();
            }

            return Ok(foundArticle);
        }
    }
}