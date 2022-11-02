using Microsoft.AspNetCore.Mvc;
using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IArticleService
    {
        public List<Article> GetAllArticles();
    }
}
