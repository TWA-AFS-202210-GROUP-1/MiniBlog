using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Service;

public interface IArticleService
{
    public Article Create(Article article);
    public List<Article> List();
    public Article GetById(Guid id);
}