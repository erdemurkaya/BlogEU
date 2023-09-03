using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.WebUI.Areas.Admin.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MyProfileController : Controller
    {

        private readonly IMyProfileService _myProfileService;

        public MyProfileController(IMyProfileService myProfileService)
        {
            _myProfileService = myProfileService;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var profile=_myProfileService.GetProfileById(id);


            var myProfileViewModel = new MyProifleEditVM()
            {
                Id = profile.Id,
                Name = profile.Name,
                LastName = profile.LastName,
                Description = profile.Description,
                GithubUrl = profile.GithubUrl,
                InstagramUrl = profile.InstagramUrl,
                LinkedInUrl = profile.LinkedInUrl
            };


            return View(myProfileViewModel);
        }
        [HttpPost]
        public IActionResult Edit(MyProifleEditVM formData)
        {

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var profile = new MyProfileEditDto()
            {
                Id = formData.Id,
                Name = formData.Name,
                LastName = formData.LastName,
                Description = formData.Description,
                GithubUrl = formData.GithubUrl,
                LinkedInUrl = formData.LinkedInUrl,
                InstagramUrl = formData.InstagramUrl

            };


            _myProfileService.UpdateProfile(profile);

            return RedirectToAction("Index", "Dashboard");



        }


    }
}
