using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.DAL.Abstract;
using Blog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Managers
{
    public class CategoryManager : ICategoryService
    {

        private readonly IRepository<CategoryEntity> _repository;

        public CategoryManager(IRepository<CategoryEntity> repository)
        {
            _repository = repository;
        }

        public void AddCategory(CategoryAddOrEditDto category)
        {
            var categoryEntity = new CategoryEntity()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };


            _repository.Add(categoryEntity);
        }

        public void DeleteCategory(int id)
        {
            
            var category= _repository.GetById(id);


            _repository.Delete(category);

        }

        public List<CategoryListDto> GetAllCategories()
        {

            var categories = _repository.GetAll(x => x.IsActive == true && x.IsDeleted == false);

            var categoryDtos = categories.Select(x => new CategoryListDto
            {
                Id=x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedDate = x.CreatedDate

            }).ToList();

            return categoryDtos;


        }

        public CategoryDto GetCategoryById(int id)
        {
            var category= _repository.GetById(id);

            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };


            return categoryDto;

        }



        public void UpdateCategory(CategoryAddOrEditDto category)
        {

            var categoryEntity = _repository.GetById(category.Id);


            categoryEntity.Name = category.Name;
            categoryEntity.Description = category.Description;

            _repository.Update(categoryEntity);

        }

        List<CategoryListDto> ICategoryService.GetCategoryOrderByTakeList()
        {
            var listEntity = _repository.GetAll(x=>x.IsDeleted==false&&x.IsActive==true).OrderByDescending(x => x.CreatedDate).Take(5).ToList();

            var categoryListDto = listEntity.Select(x => new CategoryListDto()
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name
                
            }).ToList();

            return categoryListDto;
        }
    }
}
