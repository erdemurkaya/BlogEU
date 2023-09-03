using Blog.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services
{
    public interface IPostService
    {

        void AddPost(PostAddOrEditDto post);

        void UpdatePost(PostAddOrEditDto post);

        void DeletePost(int id);

        PostDto GetPostById(int id);

        List<PostListDto> GetAllPosts();

        List<PostDto> GetCategoryListById(int? categoryId=null);

        PostDto LastPost();

        List<PostListDto> GetPostOrderBy();

        PostDto GetDetailPost(int id);



    }
}
