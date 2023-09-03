using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.WebUI.Areas.Admin.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;

namespace Blog.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class PostController : Controller
    {

        private readonly IWebHostEnvironment _environment;

        private readonly IPostService _postService;

        private readonly ICategoryService _categoryService;

        public PostController(IPostService postService, IWebHostEnvironment environment,ICategoryService categoryService)
        {
            _postService = postService;
            _environment = environment;   
            _categoryService = categoryService;
        }


        public IActionResult List()
        {

            var postDtos=_postService.GetAllPosts();

            var postListViewModel=postDtos.Select(x=>new PostListVM
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                ImagePath = x.ImagePath,
                CategoryId = x.CategoryId,
                CreatedDate=x.CreatedDate,
                LikeCount=x.LikeCount,
                ReadCount=x.ReadCount
            }).ToList();


            ViewBag.postCount=postListViewModel.Count;

            return View(postListViewModel);
        }

        [HttpGet]
        public IActionResult New(int? id)
        {

            ViewBag.categories = _categoryService.GetAllCategories();

            if (id != null)
            {

                

                var postDto = _postService.GetPostById(id.Value);

                var viewModel = new PostAddOrEditVM
                {
                    Id = postDto.Id,
                    Title = postDto.Title,
                    Content = postDto.Content,
                    CategoryId = postDto.CategoryId,

                };

                ViewBag.ImagePath = postDto.ImagePath;

                return View("Form",viewModel);

            }

            return View("Form",new PostAddOrEditVM());

            
        }
        [HttpPost]
        public IActionResult Save(PostAddOrEditVM formData)
        {


            if (!ModelState.IsValid)
            {
                ViewBag.categories = _categoryService.GetAllCategories();

                return View("Form", formData);
            }

            

            var newFileName = "";


            if (formData.File != null)
            {
                var allowedFileContentTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/jfif" };

                var allowedFileExtensions = new string[] { ".jpeg", ".png", ".jpg", ".jfif" };
                var fileContentType = formData.File.ContentType;

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(formData.File.FileName);

                var fileExtension = Path.GetExtension(formData.File.FileName);

                if (!allowedFileContentTypes.Contains(fileContentType) || !allowedFileExtensions.Contains(fileExtension))
                {

                    ViewBag.fileError = "Lütfen jpg jpeg png jfif uzantılı bir dosya türü seçiniz";

                    return View("Form", formData);
                }

                newFileName = fileNameWithoutExtension + "-" + Guid.NewGuid() + fileExtension;

                var folderPath = Path.Combine("images", "posts");

                var wwwRootFolderPath = Path.Combine(_environment.WebRootPath, folderPath);

                var wwwRootFilePath = Path.Combine(wwwRootFolderPath, newFileName);


                Directory.CreateDirectory(wwwRootFolderPath);

                using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
                {
                    formData.File.CopyTo(fileStream);
                }

            }

            if (formData.Id == 0)
            {
                var newsDto = new PostAddOrEditDto()
                {
                    Id = formData.Id,
                    Content = formData.Content,
                    Title = formData.Title,
                    CategoryId = formData.CategoryId,
                    ImagePath = newFileName
                };

                _postService.AddPost(newsDto);

                return RedirectToAction("List");
            }
            else
            {

                var postDto = new PostAddOrEditDto()
                {
                    Id = formData.Id,
                    Content = formData.Content,
                    Title = formData.Title,
                    CategoryId= formData.CategoryId

                };


                if (formData.File != null)
                {
                    postDto.ImagePath = newFileName;
                }

                _postService.UpdatePost(postDto);



                return RedirectToAction("List");
            }

            
        }

        public IActionResult Delete(int id)
        {

            _postService.DeletePost(id);

            return RedirectToAction("List");
        }

    }
}
