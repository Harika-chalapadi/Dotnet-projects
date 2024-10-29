//namespace CodeFirstAppWith2Tables.Repository
//{
//    public class IArticleRepository
//    {
//    }
//}

using CodeFirstAppWith2Tables.Models;
using CodeFirstAppWith2Tables.Models;

namespace CodeFirstAppWith2Tables.Repository
{
    public interface IArticleRepository
    {
        Article AddArticle(Article article);
        Article UpdateArticle(Article article);
        string DeleteArticle(int id);
        Article GetArticleById(int id);
        IEnumerable<Article> GetAllArticle();
        IEnumerable<Article> GetArticleByTutorialId(int tutorialId);
    }
}