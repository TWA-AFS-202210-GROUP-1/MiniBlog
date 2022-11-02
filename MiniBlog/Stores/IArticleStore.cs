using MiniBlog.Model;
using System.Collections.Generic;

namespace MiniBlog.Stores
{
    public interface IArticleStore
    {
        bool Delete(Article articles);
        List<Article> GetAll();
        Article Save(Article article);
    }
}