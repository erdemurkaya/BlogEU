using Blog.Business.Services;
using Blog.WebUI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Controllers
{
    public class PostController : Controller
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult List()
        {

            var postDto=_postService.GetAllPosts();

            var viewModel=postDto.Select(x=>new PostListVModel
            {
                Id = x.Id,
                CreatedDate=x.CreatedDate,
                Title = x.Title,
                Content = x.Content,
                CategoryId = x.CategoryId,
                ImagePath = x.ImagePath
                
            }).ToList();


            return View(viewModel);
        }


        public IActionResult Detail(int id)
        {

            var dto=_postService.GetDetailPost(id);


            var viewModel = new PostVModel
            {
                Id = dto.Id,
                Content = dto.Content,
                CreatedDate = dto.CreatedDate,
                ImagePath = dto.ImagePath,
                Title = dto.Title

            };


            return View(viewModel);
        }

    }
}
