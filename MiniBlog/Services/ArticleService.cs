using Microsoft.AspNetCore.Identity;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleStore _articleStore;
    private readonly IUserStore _userStore;

    public ArticleService(IArticleStore articleStore, IUserStore userStore)
    {
        _articleStore = articleStore;
        _userStore = userStore;
    }

    public List<Article> GetAllArticles()
    {
        return _articleStore.GetAll();
    }

    public Article? CreateArticle(Article article)
    {
        if (!string.IsNullOrEmpty(article.UserName))
        {
            if (!_userStore.GetAll().Exists(_ => article.UserName == _.Name))
            {
                _userStore.Save(new User(article.UserName));
            }

            _articleStore.Save(article);
            return article;
        }

        return null;
    }
}