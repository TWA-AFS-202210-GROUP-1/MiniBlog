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
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_articleService.GetAllArticles());
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            var createdArticle = _articleService.CreateArticle(article);
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