namespace MiniBlog.Stores
{
    using MiniBlog.Model;
    using System.Collections.Generic;
    using System.Security.AccessControl;

    public class ArticleStore : IArticleStore
    {
        private List<Article> articles;

        public ArticleStore()
        {
            this.articles = new List<Article>();
        }

        public Article Save(Article article)
        {
            this.articles.Add(article);
            return article;
        }

        public List<Article> GetAll()
        {
            return this.articles;
        }

        public bool Delete(Article articles)
        {
            return this.articles.Remove(articles);
        }
    }
}
