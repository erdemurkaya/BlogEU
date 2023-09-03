using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.DAL.Context;
using Blog.WebUI.Areas.Admin.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService, IWebHostEnvironment environment)
        {
            _newsService = newsService;
            _environment = environment;
        }

        public IActionResult List()
        {
            var newsDtos=_newsService.GetAllNews();

            var newsViewModelList = newsDtos.Select(x=>new NewsListVM
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                ImagePath=x.ImagePath,
                LikeCount=x.LikeCount,
                ReadCount=x.ReadCount
            }).ToList();

            ViewBag.NewsCount=newsViewModelList.Count;

            return View(newsViewModelList);
        }

        [HttpGet]
        public IActionResult New(int? id)
        {

            if(id != null)
            {
                var newsDto = _newsService.GetNewsById(id.Value);

                var newsViewModel = new NewsAddOrUpdateVM()
                {
                    Id = newsDto.Id,
                    Content = newsDto.Content,                   
                    Title = newsDto.Title
                };

                ViewBag.ImagePath = newsDto.Image;

                return View("Form", newsViewModel);
            }


            return View("Form",new NewsAddOrUpdateVM());
        }


        [HttpPost]
        public IActionResult Save(NewsAddOrUpdateVM formData)
        {
            if(!ModelState.IsValid)
            {
                return View("Form",formData);
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

                var folderPath = Path.Combine("images", "news");

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
                var newsDto = new NewsAddOrEditDto()
                {
                    Id = formData.Id,
                    Content = formData.Content,
                    Title = formData.Title,
                    ImagePath = newFileName
                };

                _newsService.AddNews(newsDto);

                return RedirectToAction("List");
            }
            else
            {

                var newsDto = new NewsAddOrEditDto()
                {
                    Id = formData.Id,
                    Content = formData.Content,
                    Title = formData.Title,

                };


                if (formData.File != null)
                {
                    newsDto.ImagePath = newFileName;
                }

                _newsService.UpgradeNews(newsDto);



                return RedirectToAction("List");
            }



            
        }

        public IActionResult Delete(int id)
        {

            _newsService.DeleteNews(id);

            return RedirectToAction("List");
        }
    }
}
