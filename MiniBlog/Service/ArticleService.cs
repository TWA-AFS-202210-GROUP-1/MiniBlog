using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Service
{
    public class ArticleService : IArticleService
    {
        private IArticleStore articleStore;
        private IUserStore userStore;

        public ArticleService(IArticleStore articleStore, IUserStore userStore)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
        }

        public Article Create(Article article)
        {
            if (article.UserName != null)
            {
                if (!userStore.GetAll().Exists(_ => article.UserName == _.Name))
                {
                    userStore.Save(new User(article.UserName));
                }

                articleStore.Save(article);
            }

            return article;
        }

        public List<Article> GetAll()
        {
            return articleStore.GetAll();
        }
    }
}
