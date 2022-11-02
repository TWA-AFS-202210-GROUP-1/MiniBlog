using MiniBlog.Model;
using MiniBlog.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Service
{
    public class ArticleService : IArticleService
    {
        private IArticleStore articleStore;
        private IUser userStore;

        public ArticleService(IArticleStore articleStore, IUser userStore)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
        }

        public List<Article> GetAll()
        {
            return articleStore.GetAll();
        }
    }
}
