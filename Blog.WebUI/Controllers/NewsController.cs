using Blog.Business.Services;
using Blog.WebUI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Controllers
{
    public class NewsController : Controller
    {

        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }


        public IActionResult List()
        {

            var dto=_newsService.GetAllNews();

            var viewModel = dto.Select(x => new NewsListVModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                ImagePath = x.ImagePath,
                


            }).ToList();


            return View(viewModel);
        }


        public IActionResult Detail(int id)
        {

            var news=_newsService.GetDetailNews(id);


            var viewModel = new NewsVModel
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                ImagePath = news.Image
            };



            return View(viewModel);
        }

    }
}
