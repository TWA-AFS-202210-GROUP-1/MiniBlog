using MiniBlog.Model;

namespace MiniBlog.Stores;

public class ArticleStore : IArticleStore
{
    private readonly List<Article> _articles;

    public ArticleStore()
    {
        _articles = new List<Article>();
    }


    public Article Save(Article article)
    {
        _articles.Add(article);
        return article;
    }

    public List<Article> GetAll()
    {
        return _articles;
    }

    public bool Delete(Article articles)
    {
        return _articles.Remove(articles);
    }
}