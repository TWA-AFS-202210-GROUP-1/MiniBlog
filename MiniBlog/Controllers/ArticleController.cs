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
        private IArticleStore _articleStore;
        private IUserStore _userStore;

        public ArticleController(IArticleStore articleStore, IUserStore userStore)
        {
            _articleStore = articleStore;
            _userStore = userStore;
        }

        [HttpGet]
        public List<Article> List()
        {
            return _articleStore.GetAll();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            if (article.UserName != null)
            {
                if (!_userStore.GetAll().Exists(_ => article.UserName == _.Name))
                {
                    _userStore.Save(new User(article.UserName));
                }

                //ArticleStoreWillReplaceInFuture.Instance.Save(article);
                this._articleStore.Save(article);
            }

            return Created("/article", article);
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            var foundArticle =
                ArticleStoreWillReplaceInFuture.Instance.GetAll().FirstOrDefault(article => article.Id == id);
            return foundArticle;
        }
    }
}