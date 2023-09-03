using Blog.Business.Services;
using Blog.WebUI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Controllers
{
    public class AboutController : Controller
    {

        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult AboutProfile()
        {

            var dto = _aboutService.About(1);

            var viewModel = new AboutVM()
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Description = dto.Description,
                GithubUrl = dto.GithubUrl,
                InstagramUrl = dto.InstagramUrl,
                LinkedInUrl = dto.LinkedInUrl
            };


            return View(viewModel);
        }
    }
}
