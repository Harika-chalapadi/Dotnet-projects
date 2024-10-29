using Microsoft.AspNetCore.Mvc;

namespace OurHeroApiWithCodeFirstApproach.Controllers
{
    public class OurHeroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
