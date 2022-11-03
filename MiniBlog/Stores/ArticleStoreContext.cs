using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class ArticleStoreContext: IArticleStore
    {
        private List<Article> articles = new List<Article>();

        public ArticleStoreContext()
        {
        }

        bool IArticleStore.Delete(Article articles)
        {
            return this.articles.Remove(articles);
        }

        List<Article> IArticleStore.GetAll()
        {
            return this.articles;
        }

        Article IArticleStore.Save(Article article)
        {
            this.articles.Add(article);
            return article;
        }
    }
}