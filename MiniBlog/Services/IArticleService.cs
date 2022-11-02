using Microsoft.AspNetCore.Mvc;
using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IArticleService
    {
        ActionResult<Article> Create(Article article);
        Article GetById(Guid id);
        List<Article> List();
    }
}