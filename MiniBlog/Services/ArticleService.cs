using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleStore _articleStore;

    public ArticleService(IArticleStore articleStore)
    {
        _articleStore = articleStore;
    }

    public List<Article> GetAllArticles()
    {
        return _articleStore.GetAll();
    }
}