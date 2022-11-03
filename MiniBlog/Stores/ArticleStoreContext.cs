namespace MiniBlog.Stores
{
  using MiniBlog.Model;

  public class ArticleStoreContext : IArticleStore
  {
    private readonly List<Article> articles = new ();

    /// <inheritdoc/>
    public Article Save(Article article)
    {
      articles.Add(article);
      return article;
    }

    /// <inheritdoc/>
    public List<Article> GetAll()
    {
      return articles;
    }

    /// <inheritdoc/>
    public bool Delete(Article articles)
    {
      return this.articles.Remove(articles);
    }
  }
}
