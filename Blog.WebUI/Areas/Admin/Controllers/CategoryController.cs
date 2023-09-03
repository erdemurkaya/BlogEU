using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.WebUI.Areas.Admin.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult List()
        {

            var categoryDtos=_categoryService.GetAllCategories();


            var viewModels = categoryDtos.Select(x=>new CategoryListVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
            }).ToList();


            ViewBag.CountCategory = viewModels.Count;


            return View(viewModels);
        }

        [HttpGet]
        public IActionResult New(int? id)
        {
            if(id != null)
            {
                var categoryDto = _categoryService.GetCategoryById(id.Value);

                var viewModel = new CategoryAddOrEditVM()
                {
                    Id = categoryDto.Id,
                    Name = categoryDto.Name,
                    Description = categoryDto.Description
                };


                return View("Form",viewModel);

            }
            else
            {
                return View("Form", new CategoryAddOrEditVM());
            }



            
        }
        [HttpPost]
        public IActionResult Save(CategoryAddOrEditVM formData)
        {
            if(!ModelState.IsValid)
            {
                return View("Form", formData);
            }

            if (formData.Id == 0)
            {
                var categoryDto = new CategoryAddOrEditDto()
                {
                    Id = formData.Id,
                    Name = formData.Name,
                    Description = formData.Description,
                };

                _categoryService.AddCategory(categoryDto);

                return RedirectToAction("List");
            }
            else
            {
                var categoryDto = new CategoryAddOrEditDto()
                {
                    Id = formData.Id,
                    Name = formData.Name,
                    Description = formData.Description
                };

                _categoryService.UpdateCategory(categoryDto);

                return RedirectToAction("List");

            }


            
        }

        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);

            return RedirectToAction("List");
        }
    }
}
