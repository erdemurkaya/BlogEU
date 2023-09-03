using Blog.Business.Services;
using Blog.WebUI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPostService _postService;

        private readonly INewsService _newsService;

        private readonly ICategoryService _categoryService;

        public HomeController(IPostService postService, INewsService newsService, ICategoryService categoryService)
        {
            _postService = postService;
            _newsService = newsService;
            _categoryService = categoryService;

        }


        public IActionResult Index()
        {

            


            ViewBag.postOrderTake = _postService.GetPostOrderBy();


            var lastNews = _newsService.LastNews();

            if (lastNews != null)
            {
                var newsViewModel = new NewsVModel
                {
                    Id = lastNews.Id,
                    Title = lastNews.Title,
                    Content = lastNews.Content,
                    ImagePath = lastNews.Image,

                };


                ViewBag.lastNews = newsViewModel;

            }






            ViewBag.newsOrderTake = _newsService.GetNewsOrderBy();


            ViewBag.categoryOrderTake = _categoryService.GetCategoryOrderByTakeList();



            var lastDto = _postService.LastPost();


            if (lastDto != null)
            {
                var postViewModel = new PostVModel
                {
                    Id = lastDto.Id,
                    Title = lastDto.Title,
                    Content = lastDto.Content,
                    CategoryId = lastDto.CategoryId,
                    ImagePath = lastDto.ImagePath,
                    CreatedDate = lastDto.CreatedDate
                };

                return View(postViewModel);
            }

            return View();

            
        }
    }
}
