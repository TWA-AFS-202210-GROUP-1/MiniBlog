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
    private IArticleStore articleStore;
    private IUserStore userStore;
    private IArticleService articleService;

    public ArticleController(IArticleService articleService, IArticleStore articleStore, IUserStore userStore)
    {
      this.articleStore = articleStore;
      this.userStore = userStore;
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
      return Created("/article", articleService.Create(article));
    }

    [HttpGet("{id}")]
    public Article GetById(Guid id)
    {
      var foundArticle = articleStore.GetAll().FirstOrDefault(article => article.Id == id);
      return foundArticle;
    }
  }
}