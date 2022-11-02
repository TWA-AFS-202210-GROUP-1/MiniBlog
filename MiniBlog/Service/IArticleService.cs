using MiniBlog.Model;
using System.Collections.Generic;

namespace MiniBlog.Service
{
    public interface IArticleService
    {
        List<Article> GetAll();

        Article Create(Article article);
    }
}