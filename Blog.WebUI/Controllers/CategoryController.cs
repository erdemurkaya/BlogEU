using Microsoft.AspNetCore.Mvc;



namespace Blog.WebUI.Controllers
{

    
    public class CategoryController : Controller
    {

        

        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save()
        {
            return View();
        }

        




    }
}
