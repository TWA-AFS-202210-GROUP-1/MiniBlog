namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Service;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return articleService.GetAll();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            return Created("/articles", articleService.Create(article));
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            var foundArticle =
                articleService.GetAll().FirstOrDefault(article => article.Id == id);
            return foundArticle;
        }
    }
}