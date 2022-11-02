namespace MiniBlog.Stores
{
  using MiniBlog.Model;

  public interface IArticleStore
  {
    bool Delete(Article articles);

    List<Article> GetAll();

    Article Save(Article article);
  }
}