using MiniBlog.Service;

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
        private IArticleStore articleStore;
        private IUserStore userStore;
        private IArticleService articleService;

        public ArticleController(IArticleStore articleStore, IUserStore userStore, IArticleService articleService)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
            this.articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return articleService.List();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            return Created(" ", articleService.Create(article));
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            return articleService.GetById(id);
        }
    }
}