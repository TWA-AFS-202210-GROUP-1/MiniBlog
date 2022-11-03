using MiniBlog.Model;

namespace MiniBlog.Service
{
    public interface IArticleService
    {
        Article Create(Article article);
        List<Article> GetAll();
        Article GetById(Guid guid);
    }
}