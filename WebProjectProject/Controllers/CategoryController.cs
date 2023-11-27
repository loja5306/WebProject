using Microsoft.AspNetCore.Mvc;

namespace WebProjectProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
