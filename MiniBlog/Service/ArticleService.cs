namespace MiniBlog.Service
{
  using MiniBlog.Model;
  using MiniBlog.Stores;

  public class ArticleService : IArticleService
  {
    private IArticleStore articleStore;
    private IUserStore userStore;

    public ArticleService(IArticleStore articleStore, IUserStore userStore)
    {
      this.articleStore = articleStore;
      this.userStore = userStore;
    }

    public List<Article> GetAll()
    {
      return articleStore.GetAll();
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

    public Article GetById(Guid id)
    {
      var foundArticle = articleStore.GetAll().FirstOrDefault(article => article.Id == id);

      return foundArticle;
    }
  }
}
