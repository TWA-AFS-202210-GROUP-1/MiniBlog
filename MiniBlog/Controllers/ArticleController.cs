namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Service;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;

        }

        [HttpGet]
        public ActionResult List()
        {
            return Ok(_articleService.GetAll());
        }

        [HttpPost]
        public ActionResult Create(Article article)
        {
            Article newArticle = _articleService.Create(article);

            return Created($"/article/{newArticle.Id}", article);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var foundArticle = _articleService.GetById(id);
            return Ok(foundArticle);
        }
    }
}