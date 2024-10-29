//namespace CodeFirstAppWith2Tables.Repository
//{
//    public class ArticleRepository
//    {
//    }
//}

using CodeFirstAppWith2Tables.Models;
using CodeFirstAppWith2Tables.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstAppWith2Tables.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly TutorialDbContext _context;
        public ArticleRepository(TutorialDbContext context)
        {
            _context = context;
        }

        public Article AddArticle(Article article)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.[Articles] ON");
                _context.Add(article);
                _context.SaveChanges();
                transaction.Commit();
                return article;
            }
            //throw new NotImplementedException();
        }

        //public Article AddArticle(ArticleRepository article)
        //{
        //    throw new NotImplementedException();
        //}

        public Article UpdateArticle(Article newarticle)
        {
            if (newarticle != null)
            {
                var article = _context.Articles.FirstOrDefault(a => a.ArticleId == newarticle.ArticleId);
                if (article != null)
                {
                    article.ArticleTitle = newarticle.ArticleTitle;
                    article.ArticleContent = newarticle.ArticleContent;
                    article.TutorialId = newarticle.TutorialId;
                    _context.Entry(article).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                return newarticle;
            }
            return null;
            //throw new NotImplementedException();
        }

        public string DeleteArticle(int id)
        {
            if (id > 0)
            {
                Article article = _context.Articles.FirstOrDefault(a => a.ArticleId == id);
                if (article != null)
                {
                    _context.Articles.Remove(article);
                    _context.SaveChanges();
                    return "Article removed";
                }
                else
                {
                    return "Id not Found";
                }
            }
            else
            {
                return "Id is not valid";
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllArticle()
        {
            var articles = _context.Articles;
            if (articles != null)
                return articles;
            else
                return null;
            //throw new NotImplementedException();
        }

        public Article GetArticleById(int id)
        {
            if (id != 0 || id != null)
            {
                var article = _context.Articles.FirstOrDefault(a => a.ArticleId == id);
                if (article != null)
                    return article;
            }
            return null;
            //throw new NotImplementedException();
        }

        public IEnumerable<Article> GetArticleByTutorialId(int tutorialId)
        {
            return _context.Articles.Where(a => a.TutorialId == tutorialId).ToList();
            //throw new NotImplementedException();
        }
    }
}
