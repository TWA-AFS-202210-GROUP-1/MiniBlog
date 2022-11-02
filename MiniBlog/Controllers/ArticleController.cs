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
            if (article.UserName != null)
            {
                if (!_userStore.GetAll().Exists(_ => article.UserName == _.Name))
                {
                    _userStore.Save(new User(article.UserName));
                }

                _articleStore.Save(article);
                return Created($"/article/{article.Id}", article);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            var foundArticle = _articleStore.GetAll().FirstOrDefault(article => article.Id == id);
            return foundArticle;
        }
    }
}