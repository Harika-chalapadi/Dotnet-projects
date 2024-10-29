//using Microsoft.AspNetCore.Mvc;

//namespace CodeFirstAppWith2Tables.Controllers
//{
//    public class ArticleController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
using CodeFirstAppWith2Tables.Models;
using CodeFirstAppWith2Tables.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CodeFirstAppWith2Tables.Models;
using CodeFirstAppWith2Tables.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirstAppWith2Tables.Models;
namespace CodeFirstAppWith2Table.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly TutorialDbContext _context;
        public ArticleController(IArticleRepository articleRepository, TutorialDbContext context)
        {
            _articleRepository = articleRepository;
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_articleRepository.GetAllArticle());
        }
        public IActionResult Details(int id)
        {
            return View(_articleRepository.GetArticleById(id));
        }

        public IActionResult Create()
        {
            ViewData[index: "TutorialId"] = new SelectList(_context.Tutorials, dataValueField: "TutorialId", dataTextField: "TutorialId");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(include: "ArticleId, ArticleTitle, ArticleContent, TutorialId")] Article article)
        {
            if (ModelState.IsValid)
            {
                _articleRepository.AddArticle(article);
                return RedirectToAction(actionName: "Index");

            }
            return View();
        }
        // Controller method for editing an article (GET)
        public ActionResult Edit(int id)
        {
            return View(_articleRepository.GetArticleById(id));
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {

            _articleRepository.UpdateArticle(article);
            return RedirectToAction("Index");



        }

        // Controller method for deleting an article (GET)
        public IActionResult Delete(int id)
        {
            return View(_articleRepository.GetArticleById(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _articleRepository.DeleteArticle(id)
;
            return RedirectToAction("Index");
        }
    }
}
//public IActionResult DisplayArticles(int id)
// IEnumerable<Article> articles= _articleRepository.GetArticleByTutorialId(id)
;