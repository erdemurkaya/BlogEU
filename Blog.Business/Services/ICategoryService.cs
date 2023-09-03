using Blog.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services
{
    public interface ICategoryService
    {

        void AddCategory(CategoryAddOrEditDto category);

        void UpdateCategory(CategoryAddOrEditDto category);

        void DeleteCategory(int id);

        List<CategoryListDto> GetAllCategories();

        CategoryDto GetCategoryById(int id);

        List<CategoryListDto> GetCategoryOrderByTakeList();





    }
}
