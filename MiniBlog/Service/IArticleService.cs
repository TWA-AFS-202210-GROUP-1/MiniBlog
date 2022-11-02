using MiniBlog.Model;

namespace MiniBlog.Service;

public interface IArticleService
{
    public Article Create(Article article);
}