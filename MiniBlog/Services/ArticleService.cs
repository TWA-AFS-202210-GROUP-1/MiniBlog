using System.Net;
using Microsoft.AspNetCore.Identity;
using MiniBlog.Exceptions;
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

    public Article CreateArticle(Article article)
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

        throw new HttpResponseException(HttpStatusCode.BadRequest, "Please input a valid user name.");
    }

    public Article GetArticle(Guid id)
    {
        var foundArticle = _articleStore.GetAll().FirstOrDefault(article => article.Id == id);
        if (foundArticle != null)
        {
            return foundArticle;
        }
        throw new HttpResponseException(HttpStatusCode.NotFound, $"Can not find article with id: {id}.");
    }
}