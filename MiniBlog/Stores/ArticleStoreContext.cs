using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class ArticleStoreContext : IArticleStore
    {
        bool IArticleStore.Delete(Article articles)
        {
            throw new NotImplementedException();
        }

        List<Article> IArticleStore.GetAll()
        {
            throw new NotImplementedException();
        }

        Article IArticleStore.Save(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
