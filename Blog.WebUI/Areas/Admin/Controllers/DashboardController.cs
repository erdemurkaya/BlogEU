using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class DashboardController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Logout()
        {
            

            return View("Index","Home");

        }

    }
}
